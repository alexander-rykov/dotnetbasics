namespace ValueAndReferenceTypes
{
    public class BoxingExample
    {
        public static void BoxingAndUnboxingExample()
        {
            int i = 101;
            object o = i; // "Boxing is implicit"
            int j = (int)o; // "Unboxing is explicit"
        }

        public static void SimpleBoxingExample()
        {
            int i = 1;
            int j = 2;
            object o = i;
        }
    }
}
