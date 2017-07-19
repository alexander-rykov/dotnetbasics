using System;
using MyInterfaces;

namespace MyLibrary
{
    [DoSomething]
    public class AnotherService
    {
        public Result DoSomething(Input input)
        {
            Console.WriteLine("MyService.DoSomething runs in {0}.", AppDomain.CurrentDomain.FriendlyName);

            return new Result
            {
                Value = input.Users.Length
            };
        }
    }
}
