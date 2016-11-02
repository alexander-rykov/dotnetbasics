using System;

namespace StructsApplication
{
    public struct AnotherMyStruct
    {
        public int Field7;
        public string Field8;
        public int Field9;
    }

    public class MyClass
    {
        public int Field4;
        public AnotherMyStruct Field5;
        public int Field6;
    }

    public struct MyStruct
    {
        public int Field1;
        public MyClass Field2;
        public int Field3;
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var myStruct = new MyStruct
            {
                Field1 = 0x01020304,
                Field2 = new MyClass
                {
                    Field4 = 0x04030201,
                    Field5 = new AnotherMyStruct
                    {
                        Field7 = 0x11223344,
                        Field8 = "Some string",
                        Field9 = 0x55667788
                    },
                    Field6 = 0x08070605
                },
                Field3 = 0x05060708
            };

            object o = myStruct;

            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();

            myStruct.Field1 = 0;
            o.ToString();
        }
    }
}
