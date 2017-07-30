using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace IEnumerableUnitTestProject
{
    [TestClass]
    public class MyEnumerableTest
    {
        int[] source = Enumerable.Range(1, 20).ToArray();

        [TestMethod]
        public void SimpleEveryTest()
        {
            foreach (var step in Enumerable.Range(1, 5))
            {
                Console.Write("Step {0} :", step);
                foreach (var i in source.Every(step))
                {
                    Console.Write("{0} ", i);
                }

                Console.Write("\n\n");
            }
        }

        [TestMethod]
        public void EveryWithStepFunctionTest()
        {
            foreach (var i in source.Every(x => 1))
            {
                Console.Write("{0} ", i);
            }

            Console.Write("\n\n");


            foreach (var i in source.Every(x => x))
            {
                Console.Write("{0} ", i);
            }

            Console.Write("\n\n");

            var step = 1;

            foreach (var i in source.Every(x => step++))
            {
                Console.Write("{0} ", i);
            }

            Console.Write("\n\n");

        }

        [TestMethod]
        public void MyWhereTest()
        {
            int[] source = Enumerable.Range(1, 20).ToArray();

            foreach (var i in source.MyWhere(x => x % 2 == 0).Select(x => x + 1))
            {
                Console.Write("{0} ", i);
            }

            Console.Write("\n\n");
        }
    }
}
