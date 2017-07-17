using System;
using System.Threading;

namespace UsingThreadLocalStorage
{
    public class ThreadRelevantData
    {
        public int IntValue;
    }

    public class Program
    {
        public const int ThreadsCount = 5;

        //[ThreadStatic]
        public int Identifier = -1;
        public ThreadLocal<ThreadRelevantData> Data = new ThreadLocal<ThreadRelevantData>(() => new ThreadRelevantData
        {
            IntValue = Thread.CurrentThread.ManagedThreadId
        });

        public static void Main(string[] args)
        {
            var threads = new Thread[ThreadsCount];

            var program = new Program();

            Console.WriteLine("Main thread, Identifier = {0}", program.Identifier);

            for (int i = 0; i < ThreadsCount; i++)
            {
                threads[i] = new Thread(() =>
                {
                    DoSomething1(program, i + 1);
                    Thread.Sleep(100);
                    DoSomething2(program);
                });

                threads[i].Start();
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        private static void DoSomething1(Program program, int intValue)
        {
            Console.WriteLine("Thread #{0}: {1}", Thread.CurrentThread.ManagedThreadId, program.Identifier);
            Console.WriteLine("Thread #{0}. IntValue = {1}", Thread.CurrentThread.ManagedThreadId, program.Data.Value.IntValue);
            program.Identifier = new Random().Next(0, 9);
            Thread.SetData(Thread.GetNamedDataSlot("MySlot"), new ThreadRelevantData
            {
                IntValue = program.Identifier
            });
        }

        private static void DoSomething2(Program program)
        {
            var data = (ThreadRelevantData)Thread.GetData(Thread.GetNamedDataSlot("MySlot"));
            Console.WriteLine("Thread #{0}, Identifier = {1}, IntValue = {2}, GetData = {3}", program.Identifier, Thread.CurrentThread.ManagedThreadId, program.Data.Value.IntValue, data.IntValue);
        }
    }
}
