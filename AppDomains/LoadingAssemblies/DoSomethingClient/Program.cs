using System;
using System.IO;
using System.Reflection;
using MyInterfaces;

namespace DoSomethingClient
{
    public class Program
    {
        // NOTE If you have an issue and your code changes are not applied in run time, REBUILD THE WHOLE SOLUTION.
        public static void Main(string[] args)
        {
            var input = new Input
            {
                Users = new User[]
                {
                    new User
                    {
                        Id = 1,
                        Name = "Vasily",
                        Age = 23
                    },
                    new User
                    {
                        Id = 2,
                        Name = "Semen",
                        Age = 35
                    },
                    new User
                    {
                        Id = 3,
                        Name = "Pawel",
                        Age = 22
                    }
                }
            };

            Method1(input);
            //Method2(input);

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static void Method1(Input input)
        {
            var appDomainSetup = new AppDomainSetup
            {
                ApplicationBase = AppDomain.CurrentDomain.BaseDirectory,
                PrivateBinPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MyDomain")
            };

            // TODO Create a new domain with name MyDomain and appDomainSetup.
            AppDomain domain = null;

            // TODO Create a new instance of DomainAssemblyLoader in MyDomain and unwrap it by using CreateInstanceAndUnwrap method and specifying class name.
            DomainAssemblyLoader loader = null; // domain.MethodName(Assembly.GetExecutingAssembly().FullName, typeof(ClassName).FullName);

            try
            {
                IDoSomething doSomething = null;
                var assemblyString = "MyLibrary, Version=1.2.3.4, Culture=neutral, PublicKeyToken=f46a87b3d9a80705";

                doSomething = loader.Load<IDoSomething>(assemblyString);
                var result = doSomething.DoSomething(input);

                // TODO Put a breakpoint here and take a look at doSomething and result variables in the run time.

                Console.WriteLine("Method1: {0}", result.Value);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
            }

            // TODO: Unload app. domain.
        }

        private static void Method2(Input input)
        {
            var appDomainSetup = new AppDomainSetup
            {
                ApplicationBase = AppDomain.CurrentDomain.BaseDirectory,
                PrivateBinPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MyDomain")
            };

            // TODO: Create a domain with name MyDomain and setup from appDomainSetup.
            AppDomain domain = null;

            var loader = (DomainAssemblyLoader)domain.CreateInstanceAndUnwrap(Assembly.GetExecutingAssembly().FullName, typeof(DomainAssemblyLoader).FullName);

            try
            {
                Result result = null; // TODO: Use loader here.

                Console.WriteLine("Method2: {0}", result.Value);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
            }

            // TODO: Unload domain
        }
    }
}
