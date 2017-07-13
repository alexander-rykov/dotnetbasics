using System;
using System.Threading;

namespace Resurrection
{
    public class MyFinalizedClass
    {
        public MyFinalizedClass()
        {
            Console.WriteLine("MyFinalizedClass is created.");
        }

        ~MyFinalizedClass()
        {
            Console.WriteLine("MyFinalizedClass is finalized.");

            if (Program.ContinueResurrection)
            {
                // TODO: add code here to add the object reference to f-reachable queue again.
                Console.WriteLine("MyFinalizedClass is in f-reachable queue again.");
            }
        }
    }

    // NOTE Use GC.Collect() and GC.ReRegisterForFinalize() methods to resurrect an instance of the MyFinalizedClass class when it gets finalized.
    public class Program
    {
        public static bool ContinueResurrection = true;

        public static void CreateInstance()
        {
            new MyFinalizedClass();
        }

        public static void Main(string[] args)
        {
            CreateInstance();
            Console.WriteLine("Press any key to stop resurrecting MyFinalizedClass.");

            do
            {
                Thread.Sleep(200);
                // TODO: Add code here to assure that finalization is called and all finalizers completed.

            } while (!Console.KeyAvailable);

            ContinueResurrection = false;

            // TODO: Fix an issue to have the object finalized at the end and the console output like this:
            // MyFinalizedClass is in f - reachable queue again.
            // MyFinalizedClass is finalized.
            // Press any key to exit.
            GC.Collect(0);
            // TODO: add code here.

            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }
    }
}
