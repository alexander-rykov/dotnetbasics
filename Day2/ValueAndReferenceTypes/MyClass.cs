namespace ValueAndReferenceTypes
{
    public class MyClass
    {
        public int Value;

        public static void SetStructValue(MyStruct myStruct, int value)
        {
            myStruct.Value = value;
        }

        public static void SetClassValue(MyClass myClass, int value)
        {
            myClass.Value = value;
        }
    }
}
