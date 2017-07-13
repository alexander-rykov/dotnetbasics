using System;
using System.Runtime.InteropServices;

namespace FixMe
{
    public class MyClass : IDisposable
    {
        private IntPtr _buffer;       // unmanaged resource
        private SafeHandle _resource; // managed resource
        private bool _disposed = false;

        public MyClass()
        {
            _buffer = Helper.AllocateBuffer();
            _resource = Helper.GetResource();
        }

        ~MyClass()
        {
            Dispose(true);
        }

        public virtual void Dispose()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
            {
                throw new ObjectDisposedException("This object is already disposed.");
            }
            _resource.Dispose();
            if (disposing)
            {
                if (_buffer == null)
                {
                    Helper.DeallocateBuffer(_buffer);
                }
            }
            _disposed = true;
        }

        public void DoSomething()
        {
            // Manupulation with _buffer and _resource.
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (var myClass = new MyClass())
            {
                myClass.DoSomething();
                myClass.Dispose();
                myClass.DoSomething();
            }
        }
    }
}
