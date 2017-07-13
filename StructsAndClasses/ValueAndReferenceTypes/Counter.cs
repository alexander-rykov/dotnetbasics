using System.Collections.Generic;
using System.Linq;

namespace ValueAndReferenceTypes
{
    public struct Counter
    {
        private int value;

        public int Value
        {
            get
            {
                return this.value;
            }
        }

        public static IList<Counter> CreateListOfMutableStructs(int count)
        {
            return Enumerable.Range(1, count).Select(i => new Counter()).ToArray();
        }

        public static void IncrementCounters(IList<Counter> list)
        {
            foreach (var item in list)
            {
                item.Increment();
            }
        }

        public static void DecrementCounters(IList<Counter> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i].Decrement();
            }
        }

        public void Increment()
        {
            this.value++;
        }

        public void Decrement()
        {
            this.value--;
        }
    }
}
