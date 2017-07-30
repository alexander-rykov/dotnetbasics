using System;

namespace Lambdas
{
    class Program
    {
        static void Main(string[] args)
        {
            var param = string.Empty;
            ShowMenu();
            while(param.Equals("e", StringComparison.CurrentCultureIgnoreCase) == false)
            {
                if(param.Equals("r", StringComparison.CurrentCultureIgnoreCase))
                {

                }

                param = Console.ReadLine();
            }


            Console.ReadLine();
        }

        private static void ShowMenu()
        {
            Console.WriteLine("Select e for exit;");
            Console.WriteLine("Select r for refresh;");
            Console.WriteLine("======================");
        }
    }
}
