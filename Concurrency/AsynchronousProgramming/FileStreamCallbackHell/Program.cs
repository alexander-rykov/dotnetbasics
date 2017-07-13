using System;
using System.IO;
using System.Threading;

namespace FileStreamCallbackHell
{
    class Program
    {
        private static ManualResetEvent completionOfPreviousOperation = new ManualResetEvent(false);
        private static ManualResetEvent completionOfAllOperations = new ManualResetEvent(false);
        private static ManualResetEvent fileStreamClosed = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            var buffer = new byte[1024 * 1024 * 64];

            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = (byte)i;
            }

            Console.WriteLine("Running asynchronous file operations.");
            Console.WriteLine("Current thread system ID {0}, managed ID {1}.", AppDomain.GetCurrentThreadId(), Thread.CurrentThread.ManagedThreadId);


            using (var fs = new FileStream("file.bin", FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite, 1024, true))
            {
                Console.WriteLine("BeginWrite... ");

                var result = fs.BeginWrite(buffer, 0, buffer.Length, new AsyncCallback(BeginWriteCompleted), buffer);

                completionOfPreviousOperation.WaitOne();
            }

            completionOfPreviousOperation.Reset();
            fileStreamClosed.Set();
            completionOfAllOperations.WaitOne();

            File.Delete("file.bin");

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static void BeginWriteCompleted(IAsyncResult result)
        {
            Console.WriteLine("BeginWriteCompleted thread system ID {0}, managed ID {1}.", AppDomain.GetCurrentThreadId(), Thread.CurrentThread.ManagedThreadId);

            var buffer = (byte[])result.AsyncState;

            completionOfPreviousOperation.Set();
            fileStreamClosed.WaitOne();
            fileStreamClosed.Reset();

            using (var fs = new FileStream("file.bin", FileMode.Open, FileAccess.Read, FileShare.Read, 1024, true))
            {
                Console.Write("BeginRead... ");

                fs.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(FirstBeginReadCompleted), buffer);

                completionOfPreviousOperation.WaitOne();
            }

            completionOfPreviousOperation.Reset();
            fileStreamClosed.Set();
        }

        private static void FirstBeginReadCompleted(IAsyncResult result)
        {
            Console.WriteLine("FirstBeginReadCompleted thread system ID {0}, managed ID {1}.", AppDomain.GetCurrentThreadId(), Thread.CurrentThread.ManagedThreadId);

            var buffer = (byte[])result.AsyncState;

            completionOfPreviousOperation.Set();
            fileStreamClosed.WaitOne();

            using (var fs = new FileStream("file.bin", FileMode.Open, FileAccess.Read, FileShare.Read, 1024, true))
            {
                Console.Write("BeginRead... ");

                fs.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(SecondBeginReadCompleted), buffer);

                completionOfPreviousOperation.WaitOne();
            }
        }

        private static void SecondBeginReadCompleted(IAsyncResult result)
        {
            Console.WriteLine("SecondBeginReadCompleted thread system ID {0}, managed ID {1}.", AppDomain.GetCurrentThreadId(), Thread.CurrentThread.ManagedThreadId);

            completionOfPreviousOperation.Set();
            completionOfAllOperations.Set();
        }
    }
}
