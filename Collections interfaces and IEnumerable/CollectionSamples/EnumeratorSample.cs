using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections;

namespace CollectionSamples
{
    public class SquareGenerator : IEnumerable<int>
    {
        int steps;
        public SquareGenerator(int steps)
        {
            this.steps = steps;
        }
        public IEnumerator GetEnumerator()
        {
            return new Cursor(steps);
        }
        IEnumerator<int> IEnumerable<int>.GetEnumerator()
        {
            return new Cursor(steps);
        }

        internal class Cursor : IEnumerator<int>
        {
            private int maxSteps;
            private int step = 0;
            internal Cursor(int maxSteps)
            {
                this.maxSteps = maxSteps;
            }

            #region IEnumerator<int>
            public int Current
            {
                get
                {
                    return step * step;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public void Dispose()
            {
            }

            public void Reset()
            {
                step = 0;
            }

            public bool MoveNext()
            {
                if (step < maxSteps)
                {
                    step++; return true;
                }
                return false;
            }

            #endregion
        }
    }

    public static class YieldSquareGenerator
    {
        public static IEnumerable<int> Generate(int maxStep)
        {
            for (int i = 1; i <= maxStep; i++)
                yield return i * i;
        }
    }


    [TestClass]
    public class EnumeratorSample
    {
        [TestMethod]
        public void SquareGeneratorTest()
        {
            foreach (var sq in new SquareGenerator(5))
                Console.WriteLine(sq);
        }

        [TestMethod]
        public void YieldSquareGeneratorTest()
        {
            foreach (var sq in YieldSquareGenerator.Generate(5))
                Console.WriteLine(sq);
        }

        [TestMethod]
        public void ForeachSample()
        {
            List<int> a = new List<int> { 1, 2, 3, 4 };

            foreach (var ai in a)
                Console.WriteLine(ai);

            var enumerator = a.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var ai = enumerator.Current;
                Console.WriteLine(ai);
            }
        }
    }
}
