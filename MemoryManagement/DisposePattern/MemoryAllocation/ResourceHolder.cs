using System;
using System.IO;
using System.Runtime.InteropServices;

namespace MemoryAllocation
{
    // TODO Implement Dispose pattern here using recommendation from the document
    // https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/dispose-pattern
    public class ResourceHolder
    {
        private readonly int _arraySize;
        private readonly byte _pattern;
        private readonly IntPtr _unmanagedArray;
        private readonly MemoryStream _memoryStream;

        public ResourceHolder(int arraySize, byte pattern)
        {
            _arraySize = arraySize;
            _pattern = pattern;

            var unmanagedArraySize = Marshal.SizeOf(typeof(byte)) * arraySize;
            _unmanagedArray = Marshal.AllocHGlobal(unmanagedArraySize);

            _memoryStream = new MemoryStream();
        }

        public void CopyTo()
        {
            byte[] source = new byte[_arraySize];

            for (int i = 0; i < source.Length; i++)
            {
                source[i] = _pattern;
            }

            Marshal.Copy(source, 0, _unmanagedArray, source.Length);
        }

        public void CopyFrom()
        {
            byte[] destination = new byte[_arraySize];

            Marshal.Copy(_unmanagedArray, destination, 0, destination.Length);

            for (int i = 0; i < destination.Length; i++)
            {
                if (destination[i] != _pattern)
                {
                    throw new InvalidOperationException();
                }
            }

            _memoryStream.Write(destination, 0, destination.Length);
        }

        public void Release()
        {
            Marshal.FreeHGlobal(_unmanagedArray);
            _memoryStream.Dispose();
        }
    }
}
