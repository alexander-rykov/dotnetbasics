using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace FileStreamApm
{
    class MyClass
    {
    }

    class Program
    {
        private static int callbackThreadId;
        private static int callbackManagedThreadId;

        static void Main(string[] args)
        {
            var buffer = new byte[1024 * 1024 * 512];

            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = (byte)i;
            }

            var stateObject = new MyClass();
            var stopwatch = new Stopwatch();

            Console.WriteLine("Running asynchronous file operations.");
            Console.WriteLine("Current thread system ID {0}, managed ID {1}.", AppDomain.GetCurrentThreadId(), Thread.CurrentThread.ManagedThreadId);

            
            // Case 1 - doing something while async. I/O operation is in progress.
            using (var fs = new FileStream("file.bin", FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite, 1024, true))
            {
                Console.Write("BeginWrite... ");

                stopwatch.Start();
                var result = fs.BeginWrite(buffer, 0, buffer.Length, new AsyncCallback(WriteCallback), stateObject);

                while (result.IsCompleted != true)
                {
                    // do something
                }

                stopwatch.Stop();

                Console.WriteLine("{0}ms elapsed.", stopwatch.ElapsedMilliseconds);
                Console.WriteLine("Callback was called in thread system ID {0}, managed ID {1}.", callbackThreadId, callbackManagedThreadId);
            }


            // Case 2 - waiting for the end of async. I/O operation using EndX().
            /*
            using (var fs = new FileStream("file.bin", FileMode.Open, FileAccess.Read, FileShare.Read, 1024, true))
            {
                stopwatch.Reset();

                Console.Write("BeginRead... ");

                stopwatch.Start();
                var result = fs.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(WriteCallback), stateObject);

                // TODO Use relevant EndX() method here.

                stopwatch.Stop();

                Console.WriteLine("{0}ms elapsed.", stopwatch.ElapsedMilliseconds);
                Console.WriteLine("Callback was called in thread system ID {0}, managed ID {1}.", callbackThreadId, callbackManagedThreadId);
            }
            */


            // Case 3 - waiting for the end of async. I/O operation using WaitHandle object.
            /*
            using (var fs = new FileStream("file.bin", FileMode.Open, FileAccess.Read, FileShare.Read, 1024, true))
            {
                stopwatch.Reset();

                Console.Write("BeginRead... ");
                stopwatch.Start();

                var result = fs.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(WriteCallback), stateObject);

                // TODO Use result's WaitHandle to wait.

                stopwatch.Stop();

                Console.WriteLine("{0}ms elapsed.", stopwatch.ElapsedMilliseconds);
                Console.WriteLine("Callback was called in thread system ID {0}, managed ID {1}.", callbackThreadId, callbackManagedThreadId);
            }
            */

            File.Delete("file.bin");

            Console.ReadKey();
        }

        private static void WriteCallback(IAsyncResult result)
        {
            // TODO Investigate result.AsyncState.GetType() == ?
            // TODO Investigate result.AsyncWaitHandle == ?

            callbackThreadId = AppDomain.GetCurrentThreadId();
            callbackManagedThreadId = Thread.CurrentThread.ManagedThreadId;
        }
    }
}
