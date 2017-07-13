using System;

namespace XmlSerializer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press enter to exit.");

            do
            {
                new System.Xml.Serialization.XmlSerializer(typeof(object), new Type[] { });
            }
            while (!Console.KeyAvailable);
        }
    }
}
