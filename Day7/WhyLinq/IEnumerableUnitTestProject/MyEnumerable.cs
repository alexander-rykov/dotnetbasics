using System;
using System.Collections.Generic;

namespace IEnumerableUnitTestProject
{
    public static class MyEnumerable
    {
        public static IEnumerable<T> Every<T>(this IEnumerable<T> source, int step)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (step <= 0)
                throw new ArgumentException("Argument 'step' should be greater than 0", "step");

            var sourceEnumerator = source.GetEnumerator();
            sourceEnumerator.Reset();

            int i;

            do
            {
                i = step;

                while (i > 0 && sourceEnumerator.MoveNext())
                    i--;

                if (i == 0)
                    yield return sourceEnumerator.Current;
            }
            while (i == 0);
        }

        public static IEnumerable<T> Every<T>(this IEnumerable<T> source, Func<T, int> stepFunction)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (stepFunction == null)
                throw new ArgumentNullException("stepFunction");

            var sourceEnumerator = source.GetEnumerator();
            sourceEnumerator.Reset();

            int i;

            if (sourceEnumerator.MoveNext())
            {
                yield return sourceEnumerator.Current;

                do
                {
                    i = Math.Max(stepFunction(sourceEnumerator.Current), 1);

                    while (i > 0 && sourceEnumerator.MoveNext())
                        i--;

                    if (i == 0)
                        yield return sourceEnumerator.Current;
                }
                while (i == 0);
            }
        }


        public static IEnumerable<T> MyWhere<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (predicate == null) throw new ArgumentNullException("predicate");

            foreach (var e in source)
            {
                if (predicate(e))
                    yield return e;
            }
        }
    }
}
