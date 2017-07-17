using System;
using System.Diagnostics;
using System.Net;
using System.Threading;

// This lab trains the following skills:
// 1. Queueing a new work on a thread pool.
// 2. Using shared memory for inter-thread communication.
// 3. Configuring a thread pool by setting the maximum amount of working threads.

namespace UsingThreadPool
{
    public class Program
    {
        private const int MaxWorkerThreads = 1;

        // NOTE Use this documentation page to complete this task:
        // https://msdn.microsoft.com/en-us/library/system.threading.threadpool(v=vs.110).aspx
        public static void Main(string[] args)
        {
            string[] urls =
            {
                "http://microsoft.com",
                "http://www.learnasync.net/",
                "http://www.albahari.com/threading/",
                "http://jonskeet.uk/csharp/threads/",
                "https://stephencleary.com/book/",
                "https://docs.microsoft.com/en-us/dotnet/standard/threading/the-managed-thread-pool",
                "https://mva.microsoft.com/search/SearchResults.aspx#!q=Jeffrey%20Richter%20Threading&lang=1033",
                "https://channel9.msdn.com/Events/Build/2012/3-011",
                "https://codewala.net/2015/07/29/concurrency-vs-multi-threading-vs-asynchronous-programming-explained/",
                "http://dotnetpattern.com/multi-threading-interview-questions",
                "https://www.pluralsight.com/courses/skeet-async",
                "https://rsdn.org/article/dotnet/CSThreading1.xml"
            };

            var results = new string[urls.Length];
            var completed = new bool[urls.Length];

            for (int i = 0; i < completed.Length; i++)
            {
                completed[i] = false;
            }

            PrintThreadPoolConfiguration();

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < urls.Length; i++)
            {
                int index = i;

                // TODO The following block (in brackets) is a worker task. Queue it for execution using thread pool thread.
                {
                    Console.WriteLine("#{0} - Receiving data from {1}.", Thread.CurrentThread.ManagedThreadId, urls[index]);

                    try
                    {
                        var webClient = new WebClient();
                        var bytes = webClient.DownloadData(urls[index]);
                        var resultString = System.Text.Encoding.UTF8.GetString(bytes);
                        results[index] = resultString;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("#{0} - !!! Exception when receiving data: {1}", Thread.CurrentThread.ManagedThreadId, e.Message);
                        results[index] = string.Empty;
                    }
                    finally
                    {
                        completed[index] = true;
                    }

                    Console.WriteLine("#{0} - >>> Data from {1} are received.", Thread.CurrentThread.ManagedThreadId, urls[index]);
                }
            }

            Console.WriteLine("Waiting for worker threads...");

            while (WaitForWorkers(completed))
            {
            }

            stopwatch.Stop();

            Console.WriteLine("Total time is {0}s.", stopwatch.ElapsedMilliseconds / 1000);

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        // TODO Add implementation to WaitForWorkers method that will allow main thread to wait until all workers will complete their work.
        private static bool WaitForWorkers(bool[] completed)
        {
            return false;
        }

        private static void PrintThreadPoolConfiguration()
        {
            int threads;
            int ioThreads;
            ThreadPool.GetAvailableThreads(out threads, out ioThreads);

            Console.WriteLine("Current Thread Pool Configuration: {0} threads, {1} I/O threads.", threads, ioThreads);
            Console.WriteLine("Changing the amount of worker threads to {0}", MaxWorkerThreads);

            // TODO Set the maximum amount of worker threads == MaxWorkerThreads.

            // TODO Get the maximum amount of worker threads and save it to threads variable for comparison.

            if (threads != MaxWorkerThreads)
            {
                Console.WriteLine("!!! Error !!! Worker threads amount is not set. Change the MaxWorkerThreads to find the minimum number allowed.");
            }
        }
    }
}
