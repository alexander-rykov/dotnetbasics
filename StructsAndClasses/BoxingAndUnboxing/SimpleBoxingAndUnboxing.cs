namespace BoxingAndUnboxing
{
    public class SimpleBoxingAndUnboxing
    {
        public static void Example()
        {
            int i = 101;
            object o = i; // "Boxing is implicit"
            int j = (int)o; // "Unboxing is explicit"
        }
    }
}
