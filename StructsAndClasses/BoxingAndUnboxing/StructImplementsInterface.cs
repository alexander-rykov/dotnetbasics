using System;

namespace BoxingAndUnboxing
{
    public class StructImplementsInterface
    {
        interface IHasValue
        {
            int Value { get; set; }
        }

        struct MyStruct : IHasValue
        {
            int _value;

            public int Value
            {
                get
                {
                    return _value;
                }
                set
                {
                    _value = value;
                }
            }
        }

        public static void Example()
        {
            var myStruct = new MyStruct();
            myStruct.Value = 10;
            IHasValue hasValue = myStruct;
            hasValue.Value = 20;

            Console.WriteLine("myStruct.Value = {0}", myStruct.Value);
        }
    }
}
