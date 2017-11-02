using System;

namespace CustomAttributes
{
    public class MyService
    {
        public int DoSomething(string stringParameter, int parameter)
        {
            Console.WriteLine($"MyService.DoSomething({stringParameter}, {parameter})");

            return parameter * 2;
        }

        public int DoSomethingElse(int x, int y)
        {
            int value = 0;

            Console.WriteLine($"MyService.DoSomethingElse({y}, {y}) = {value}");
            return value;
        }

        private int CalculateSum(int x, int y)
        {
            int value = x + y;

            Console.WriteLine($"MyService.CalculateSum({y}, {y}) = {value}");
            return value;
        }
    }
}
