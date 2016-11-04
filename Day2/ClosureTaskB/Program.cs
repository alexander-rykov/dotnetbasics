using System;
using System.Collections.Generic;
using System.Linq;

namespace ClosureTaskB
{
    public class Program
    {
        static void Func(Action a1, Action a2)
        {

        }

        public static void Main()
        {
            object o;
            object o2;

            Func(() => { o.ToString(); }, () => { Console.WriteLine(o2); });


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
