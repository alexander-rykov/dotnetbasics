namespace Delegates
{
    public class MyAnotherClass
    {
        public event SimpleDelegate Delegate1 = { };

        public event AdvancedDelegate Delegate2;

        public void UseDelegate()
        {
            var del = Delegate1;
            if (del != null)
            {
                /// <-----
                Delegate1();
            }
        }
    }
}
