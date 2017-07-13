using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FileStreamAsync
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncHelper.RunSync(DoSomething);

            File.Delete("file.bin");

            Console.ReadKey();
        }

        private static async Task DoSomething()
        {
            var buffer = new byte[1024 * 1024 * 512];

            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = (byte)i;
            }

            var stopwatch = new Stopwatch();

            Console.WriteLine("Running asynchronous file operations.");
            Console.WriteLine("Current thread system ID {0}, managed ID {1}.", AppDomain.GetCurrentThreadId(), Thread.CurrentThread.ManagedThreadId);

            using (var fs = new FileStream("file.bin", FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite, 1024, true))
            {
                Console.Write("WriteAsync... ");
                stopwatch.Start();

                await fs.WriteAsync(buffer, 0, buffer.Length);

                stopwatch.Stop();

                Console.WriteLine("{0}ms elapsed.", stopwatch.ElapsedMilliseconds);
                Console.WriteLine("Callback was called in thread system ID {0}, managed ID {1}.", AppDomain.GetCurrentThreadId(), Thread.CurrentThread.ManagedThreadId);
            }

            using (var fs = new FileStream("file.bin", FileMode.Open, FileAccess.Read, FileShare.Read, 1024, true))
            {
                stopwatch.Reset();
                Console.Write("BeginRead... ");
                stopwatch.Start();

                await fs.ReadAsync(buffer, 0, buffer.Length);

                Console.WriteLine("{0}ms elapsed.", stopwatch.ElapsedMilliseconds);
                Console.WriteLine("Callback was called in thread system ID {0}, managed ID {1}.", AppDomain.GetCurrentThreadId(), Thread.CurrentThread.ManagedThreadId);
            }

            using (var fs = new FileStream("file.bin", FileMode.Open, FileAccess.Read, FileShare.Read, 1024, true))
            {
                stopwatch.Reset();
                Console.Write("BeginRead... ");
                stopwatch.Start();

                await fs.ReadAsync(buffer, 0, buffer.Length);

                Console.WriteLine("{0}ms elapsed.", stopwatch.ElapsedMilliseconds);
                Console.WriteLine("Callback was called in thread system ID {0}, managed ID {1}.", AppDomain.GetCurrentThreadId(), Thread.CurrentThread.ManagedThreadId);
            }
        }
    }
}
