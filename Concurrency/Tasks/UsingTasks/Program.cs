using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UsingTasks
{
    public class Program
    {
        public const string Token = "Thread";

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
                "http://asd234efwdw23reefsfdsfds.com",
                "https://codewala.net/2015/07/29/concurrency-vs-multi-threading-vs-asynchronous-programming-explained/",
                "http://dotnetpattern.com/multi-threading-interview-questions",
                "https://www.pluralsight.com/courses/skeet-async",
                "https://rsdn.org/article/dotnet/CSThreading1.xml"
            };

            var tasks = new Task<int>[urls.Length];

            for (int i = 0; i < tasks.Length; i++)
            {
                var index = i;

                // TODO Create a new task using static Task method, queue it to run, and save the task to tasks array. Use the block below as an Action delegate parameter.
                var task = Task<int>.Factory.StartNew(() =>
                {
                    Console.WriteLine("Task {0} is started. Downloading {1}", Task.CurrentId, urls[index]);

                    var webClient = new WebClient();

                    var bytes = webClient.DownloadData(urls[index]);
                    var resultString = Encoding.UTF8.GetString(bytes);
                    var occurences = IndexesOf(resultString, Token).Length;

                    Console.WriteLine("Task {0} is completed.", Task.CurrentId);

                    // TODO Make occurences variable a task result.
                    return i;
                }
                tasks[index] = task;
            }

            Console.WriteLine("Waiting for tasks to complete.");

            try
            {
                // TODO Use tasks array to wait until all the tasks will complete their work.
                Task.WaitAll(tasks);
            }
            catch
            {
                // NOTE Eat an exception here because we will process this exception later.
            }

            Console.WriteLine("\nResults for searching '{0}' word:", Token);
            for (int i = 0; i < urls.Length; i++)
            {
                Console.WriteLine("{0} - {1}", urls[i], !tasks[i].IsFaulted ? tasks[i].Result.ToString() : tasks[i].Exception.InnerException.Message);
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static int[] IndexesOf(string str, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("value is empty", "value");
            }

            List<int> indexes = new List<int>();
            for (int index = 0; ; index += value.Length)
            {
                index = str.IndexOf(value, index);
                if (index == -1)
                {
                    return indexes.ToArray();
                }

                indexes.Add(index);
            }
        }
    }
}
