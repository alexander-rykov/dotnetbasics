using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Xml;
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

            //Method1(input);
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

            // TODO Subscribe to the event that will be raised when assembly is loaded.
            {
                // TODO Set a full name of an assembly that is loaded.
                string assemblyFullName = string.Empty;
                Console.WriteLine("Assembly {0} is loaded.", assemblyFullName);
            };

            // TODO Create a new instance of DomainAssemblyLoader in MyDomain and unwrap it by using CreateInstanceAndUnwrap method and specifying class name.
            DomainAssemblyLoader loader = null; // domain.MethodName(Assembly.GetExecutingAssembly().FullName, typeof(ClassName).FullName);

            try
            {
                var assemblyString = "MyLibrary, Version=1.2.3.4, Culture=neutral, PublicKeyToken=f46a87b3d9a80705";

                // NOTE You will get an exception about serialization issues. Try to fix that using SerializableAttribute or MarshalByRefObject.
                IDoSomething doSomething = loader.Load<IDoSomething>(assemblyString);
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

            // TODO Create a new domain with name MyDomain and appDomainSetup.
            AppDomain domain = null;

            // TODO Subscribe to the event that will be raised when assembly is loaded.
            {
                // TODO Set a full name of an assembly that is loaded.
                string assemblyFullName = string.Empty;
                Console.WriteLine("Assembly {0} is loaded.", assemblyFullName);
            };

            // TODO Create a new instance of DomainAssemblyLoader in MyDomain and unwrap it.
            DomainAssemblyLoader loader = null;

            try
            {
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"MyDomain\MyLibrary.dll");

                // NOTE You will get an exception about serialization issues. Try to fix that using SerializableAttribute or MarshalByRefObject.
                Result result = loader.LoadFile<IDoSomething, DoSomethingAttribute>(path, "DoSomething", input);

                if (result.Value != 3)
                {
                    // If value != 3 that means that wrong service was called.
                    Debugger.Break();
                }

                Console.WriteLine("Method2: {0}", result.Value);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
            }

            // TODO Unload app. domain.
        }
    }
}
