using System;

namespace Delegates
{
    public delegate int SimpleDelegate();

    public delegate int AdvancedDelegate(int i, object o, Delegate d);

    public class MyClass
    {
        private readonly int _value;

        public MyClass(int value)
        {
            this._value = value;
        }

        private static int MyMethod1()
        {
            return 1;
        }

        private int Method2()
        {
            return this._value;
        }

        private static Delegate MyMethod3(Delegate @delegate)
        {
            var myClass = new MyClass(2);
            return Delegate.Combine(@delegate, new SimpleDelegate(myClass.Method2));
        }

        public static SimpleDelegate MyUsageMethod1()
        {
            return (SimpleDelegate)MyMethod3(new SimpleDelegate(MyMethod1));
        }
    }
}
