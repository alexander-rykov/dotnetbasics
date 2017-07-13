using System;

namespace DisposableStruct
{
    struct DisposableStruct : IDisposable
    {
        public bool _disposed;

        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            Console.WriteLine("DisposableStruct is disposed.");
            _disposed = true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var s1 = new DisposableStruct();

            using (s1)
            {
                using (s1)
                {
                    // do something
                }
            }

            if (s1._disposed != true) // BTW, pay attention to "!= true" instead of using bang operator.
            {
                s1.Dispose();
            }

            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }
    }
}
