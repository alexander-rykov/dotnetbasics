using System;
using System.Reflection;

// Expected result:
// All loaded assemblies in MyDomain domain:
//        mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
//        Microsoft.VisualStudio.HostingProcess.Utilities, Version= 14.0.0.0, Culture= neutral, PublicKeyToken= b03f5f7f11d50a3a
// Hello there!
// InValue is 2
// Press any key to exit.

namespace UsingAppDomains
{
    // TODO Fix an exception by marking this type as a serializable.
    public class MyClass
    {
        public int IntValue;
    }

    public class Program
    {
        public static MyClass MyClass;

        public static void Main(string[] args)
        {
            // TODO Modify the line below to create a new app. domain with name MyDomain.
            AppDomain domain = null;

            Console.WriteLine("All assemblies in {0} domain:", domain.FriendlyName);

            // TODO Modify the line below to get all assemblies that are loaded to MyDomain.
            Assembly[] assemblies = {};

            foreach (var assembly in assemblies)
            {
                Console.WriteLine("\t{0}", assembly.FullName);
            }

            var myClass = new MyClass
            {
                IntValue = 1
            };

            domain.SetData("MyMessage", "Hello there!");

            // TODO Fix a issue with accessing to myClass variable by creating a new static method and passing it as a delegate.
            domain.DoCallBack(() =>
            {
                Console.WriteLine("{0}", AppDomain.CurrentDomain.GetData("MyMessage"));

                if (myClass == null)
                {
                    Console.WriteLine("MyClass is null.");
                }
                else
                {
                    myClass.IntValue = 2;
                }
            });

            Console.WriteLine("InValue is {0}", myClass.IntValue);

            // TODO Unload app. domain.
            AppDomain.Unload(domain);

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
