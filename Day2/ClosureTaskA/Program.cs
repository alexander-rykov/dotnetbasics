using System;
using System.Collections.Generic;
using System.Linq;

namespace ClosureTaskA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var actions = new List<Action>();
            int counter = 1;

            foreach (var i in Enumerable.Range(1, 3))
            {
                actions.Add(() => Console.WriteLine(i + ", " + counter));
                counter++;
            }

            foreach (var action in actions)
            {
                action();
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }
    }
}
