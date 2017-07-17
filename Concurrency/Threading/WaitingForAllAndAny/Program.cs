using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;

namespace WaitingForAllAndAny
{
    public class Program
    {
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

            var results = new List<string>();
            var resultsMutex = new Mutex();

            for (int i = 0; i < urls.Length; i++)
            {
                int index = i;

                ThreadPool.QueueUserWorkItem((object o) =>
                {
                    Console.WriteLine("#{0} - started.", Thread.CurrentThread.ManagedThreadId);

                    resultsMutex.WaitOne();

                    try
                    {
                        Console.WriteLine("#{0} - Receiving data from {1}.", Thread.CurrentThread.ManagedThreadId, urls[index]);

                        var webClient = new WebClient();
                        var bytes = webClient.DownloadData(urls[index]);
                        var resultString = System.Text.Encoding.UTF8.GetString(bytes);

                        results.Add(resultString);

                        Console.WriteLine("#{0} - >>> Data from {1} are received.", Thread.CurrentThread.ManagedThreadId, urls[index]);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("#{0} - !!! Exception when receiving data: {1}", Thread.CurrentThread.ManagedThreadId, e.Message);
                    }
                    finally
                    {
                        resultsMutex.ReleaseMutex();
                    }
                });
            }

            Thread.Sleep(50);

            Console.WriteLine("Waiting for workers to complete.");

            resultsMutex.WaitOne();

            Console.WriteLine("Total results amount is {0}.", results.Count);

            resultsMutex.ReleaseMutex();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
