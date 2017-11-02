using System;

namespace CustomAttributes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var myService = new MyService();
            var proxyService = new MyProxyService(myService);

            Console.WriteLine("MyProperty: {0}", proxyService.DoSomething("Some text", 37) == 74);
            Console.WriteLine("MyProperty: {0}", proxyService.MyProperty == "SomeValue");
            Console.WriteLine("MyProperty: {0}", proxyService.AnotherProperty == 135);
            Console.WriteLine("MyProperty: {0}", proxyService.DoSomethingElse(15, 25) == 40);
        }
    }
}
