using System;

namespace EventAndLambda
{
    class Program
    {
        public static event EventHandler OnSomethingHappened;

        static void Main(string[] args)
        {
            Console.WriteLine("Press enter to exit.");

            do
            {
                object o = new object[1000];

                OnSomethingHappened += (sender, eventArgs) =>
                {
                    Console.WriteLine(o.GetType());
                };

                new System.Xml.Serialization.XmlSerializer(typeof(object), new Type[] { });
            }
            while (!Console.KeyAvailable);
        }
    }
}
