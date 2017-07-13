using System;

namespace XmlSerializer
{
    class Program
    {
        // More information about memory leak in XmlSerializer
        // https://blogs.msdn.microsoft.com/tess/2006/02/15/net-memory-leak-xmlserializing-your-way-to-a-memory-leak/
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
