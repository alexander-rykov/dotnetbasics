using System;
using System.Text;

namespace StringBuilderExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < 1000; i++)
            {
                sb.AppendFormat("-{0} test string-", i);
            }

            Console.WriteLine(sb.Length);
            Console.ReadLine();
        }
    }
}
