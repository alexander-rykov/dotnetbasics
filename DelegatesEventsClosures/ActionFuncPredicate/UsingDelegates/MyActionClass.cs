namespace UsingDelegates
{
    public class MyActionClass
    {
        public int Result
        {
            get;
            private set;
        }

        public void SetOneTwoThree()
        {
            Result = 123;
        }

        public void SetResult(int arg1)
        {
            Result = arg1;
        }

        public void SubtractAndSet(int arg1, int arg2)
        {
            Result = arg1 - arg2;
        }

        public void SumAndSet(int arg1, int arg2, int arg3)
        {
            Result = arg1 + arg2 + arg3;
        }

        public void MultiplyAndSet(int arg1, int arg2, int arg3, int arg4)
        {
            Result = arg1 * arg2 * arg3 * arg4;
        }
    }
}
