using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;

namespace UsingMutexForSequence
{
    public class Program
    {
        private static int _threadsStarted = 0;

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

            // This collection is a shared resource.
            var results = new List<string>();
            var resultsMutex = new Mutex();

            for (int i = 0; i < urls.Length; i++)
            {
                int index = i;

                // And this WebClient is a shared resource too.
                var webClient = new WebClient();

                // TODO (1) The following block (in brackets) is a worker task. Queue it for execution using thread pool thread.
                {
                    Interlocked.Increment(ref _threadsStarted);

                    // TODO (2) Use resultsMutex to protect all shared resources in the block below. Also, consider a situation when an exception is thrown inside the block.
                    {
                        Console.WriteLine("#{0} - Receiving data from {1}.", Thread.CurrentThread.ManagedThreadId, urls[index]);

                        var bytes = webClient.DownloadData(urls[index]);
                        var resultString = System.Text.Encoding.UTF8.GetString(bytes);

                        results.Add(resultString);

                        Console.WriteLine("#{0} - >>> Data from {1} are received.", Thread.CurrentThread.ManagedThreadId, urls[index]);
                    }
                }
            }

            // TODO (4) After completing the task and running the application, modify the value the timeout to have results.Count == 12.
            Thread.Sleep(10);

            var threadsStarted = _threadsStarted;
            Console.WriteLine("Waiting for workers to complete. {0} threads are already started.", threadsStarted);

            // TODO (3) Use resultsMutex to protect collection in the block below.
            {
                Console.WriteLine("Total results amount is {0}.", results.Count);
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
