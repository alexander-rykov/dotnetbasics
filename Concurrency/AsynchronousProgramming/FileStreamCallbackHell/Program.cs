using System;
using System.IO;
using System.Threading;

namespace FileStreamCallbackHell
{
    class Program
    {
        private static ManualResetEvent _mre1 = new ManualResetEvent(false);
        private static ManualResetEvent _mre2 = new ManualResetEvent(false);
        private static ManualResetEvent _mre3 = new ManualResetEvent(false);
        private static ManualResetEvent _mre4 = new ManualResetEvent(false);
        private static ManualResetEvent _mre5 = new ManualResetEvent(false);
        private static ManualResetEvent _mre6 = new ManualResetEvent(false);

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

                _mre1.WaitOne();
            }

            _mre5.Set();
            _mre4.WaitOne();

            File.Delete("file.bin");

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static void BeginWriteCompleted(IAsyncResult result)
        {
            Console.WriteLine("BeginWriteCompleted thread system ID {0}, managed ID {1}.", AppDomain.GetCurrentThreadId(), Thread.CurrentThread.ManagedThreadId);

            var buffer = (byte[])result.AsyncState;

            _mre1.Set();
            _mre5.WaitOne();

            using (var fs = new FileStream("file.bin", FileMode.Open, FileAccess.Read, FileShare.Read, 1024, true))
            {
                Console.Write("BeginRead... ");

                fs.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(FirstBeginReadCompleted), buffer);

                _mre2.WaitOne();
            }

            _mre6.Set();
        }

        private static void FirstBeginReadCompleted(IAsyncResult result)
        {
            Console.WriteLine("FirstBeginReadCompleted thread system ID {0}, managed ID {1}.", AppDomain.GetCurrentThreadId(), Thread.CurrentThread.ManagedThreadId);

            var buffer = (byte[])result.AsyncState;

            _mre2.Set();
            _mre6.WaitOne();

            using (var fs = new FileStream("file.bin", FileMode.Open, FileAccess.Read, FileShare.Read, 1024, true))
            {
                Console.Write("BeginRead... ");

                fs.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(SecondBeginReadCompleted), buffer);

                _mre3.WaitOne();
            }
        }

        private static void SecondBeginReadCompleted(IAsyncResult result)
        {
            Console.WriteLine("SecondBeginReadCompleted thread system ID {0}, managed ID {1}.", AppDomain.GetCurrentThreadId(), Thread.CurrentThread.ManagedThreadId);

            _mre3.Set();
            _mre4.Set();
        }
    }
}
