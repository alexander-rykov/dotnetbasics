using System;

namespace UsingAppDomainEvents
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // TOD Create a new app. domain with name "MyDomain"
            AppDomain domain = null;

            // TODO Add an event handler for the case when a domain is unloaded.
            {
                Console.WriteLine("Domain MyDomain is unloaded. Current app. domain is {0}.", AppDomain.CurrentDomain.FriendlyName);
            };

            // TODO Add an event handler for the case when an exception is raised.
            {
                // TODO Set exception message.
                string exceptionMessage = string.Empty;
                Console.WriteLine("First change exception: {0}. Current app. domain is {1}.", exceptionMessage, AppDomain.CurrentDomain.FriendlyName);
            };

            // TODO Add an event handler for the case when an exception is raised and is not handled.
            {
                // TODO Set exception type name.
                string exceptionType = string.Empty;
                Console.WriteLine("Unhandled exception: {0}. Current app. domain is {1}.", exceptionType, AppDomain.CurrentDomain.FriendlyName);
            };

            Console.WriteLine("Current domain is {0}.", AppDomain.CurrentDomain.FriendlyName);

            // TODO Invoke an anonymous deleage as a callback in newly created app. domain.
            {
                Console.WriteLine("This code is running in domain is {0}.", AppDomain.CurrentDomain.FriendlyName);

                try
                {
                    throw new ArgumentException("Just an another exception.");
                }
                catch
                {
                    // Eat the exception.
                }

                throw new InvalidOperationException("Operation is invalid. Terminating an execution.");
            }

            // TODO Unload app. domain.

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
