namespace ValueAndReferenceTypes
{
    public class ClassWithCounter
    {
        public readonly Counter FirstCounter = new Counter();

        public Counter SecondCounter = new Counter();

        public void IncrementFirstCounter()
        {
            this.FirstCounter.Increment();
        }

        public void IncrementSecondCounter()
        {
            this.SecondCounter.Increment();
        }
    }
}
