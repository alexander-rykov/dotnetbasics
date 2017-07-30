using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace StandardQueryOperators
{
    [TestClass]
    public class ElementOperators : BaseTestClass
    {
        [TestMethod]
        public void ElementOperatorsTestMethod1()
        {
            var intList = new List<int>() { 7, 10, 21, 30, 45, 50, 87 };
            var strList = new List<string>() { null, "Two", "Three", "Four", "Five" };
            var emptyList = new List<string>();

            Console.WriteLine("1st Element in intList: {0}", intList.First());
            Console.WriteLine("1st Even Element in intList: {0}", intList.First(i => i % 2 == 0));

            Console.WriteLine("1st Element in strList: {0}", strList.First());

            Console.WriteLine("emptyList.First() throws an InvalidOperationException");
            Console.WriteLine("-------------------------------------------------------------");

            try
            {
                Console.WriteLine(emptyList.First());
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        [TestMethod]
        public void ElementOperatorsTestMethod2()
        {
            try
            {
                IList<int> intList = new List<int>() { 7, 10, 21, 30, 45, 50, 87 };
                IList<string> strList = new List<string>() { null, "Two", "Three", "Four", "Five" };
                IList<string> emptyList = new List<string>();

                Console.WriteLine("1st Element in intList: {0}", intList.FirstOrDefault());
                Console.WriteLine("1st Even Element in intList: {0}", intList.FirstOrDefault(i => i % 2 == 0));

                Console.WriteLine("1st Element in strList: {0}", strList.FirstOrDefault());

                Console.WriteLine("1st Element in emptyList: {0}", emptyList.FirstOrDefault());
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void ElementOperatorsTestMethod3()
        {
            var intList = new List<int>() { 7, 10, 21, 30, 45, 50, 87 };
            var strList = new List<string>() { null, "Two", "Three", "Four", "Five" };
            var emptyList = new List<string>();

            Console.WriteLine("1st Element in intList: {0}", intList.Last());
            Console.WriteLine("1st Even Element in intList: {0}", intList.Last(i => i % 2 == 0));

            Console.WriteLine("1st Element in strList: {0}", strList.Last());

            Console.WriteLine("emptyList.Last() throws an InvalidOperationException");
            Console.WriteLine("-------------------------------------------------------------");

            try
            {
                Console.WriteLine(emptyList.Last());
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        [TestMethod]
        public void ElementOperatorsTestMethod4()
        {
            try
            {
                IList<int> intList = new List<int>() { 7, 10, 21, 30, 45, 50, 87 };
                IList<string> strList = new List<string>() { null, "Two", "Three", "Four", "Five" };
                IList<string> emptyList = new List<string>();

                Console.WriteLine("1st Element in intList: {0}", intList.LastOrDefault());
                Console.WriteLine("1st Even Element in intList: {0}", intList.LastOrDefault(i => i % 2 == 0));

                Console.WriteLine("1st Element in strList: {0}", strList.LastOrDefault());

                Console.WriteLine("1st Element in emptyList: {0}", emptyList.LastOrDefault());
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void ElementOperatorsTestMethod5()
        {
            IList<int> oneElementList = new List<int>() { 7 };
            IList<int> intList = new List<int>() { 7, 10, 21, 30, 45, 50, 87 };
            IList<string> strList = new List<string>() { null, "Two", "Three", "Four", "Five" };
            IList<string> emptyList = new List<string>();

            try
            {
                //following throws error because list contains more than one element which is less than 100
                Console.WriteLine("Element less than 100 in intList: {0}", intList.Single(i => i < 100));
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                //following throws error because list contains more than one element which is less than 100
                Console.WriteLine("Element less than 100 in intList: {0}", intList.SingleOrDefault(i => i < 100));
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                //following throws error because list contains more than one elements
                Console.WriteLine("The only Element in intList: {0}", intList.Single());
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                //following throws error because list contains more than one elements
                Console.WriteLine("The only Element in intList: {0}", intList.SingleOrDefault());
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                //following throws error because list does not contains any element
                Console.WriteLine("The only Element in emptyList: {0}", emptyList.Single());
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Console.WriteLine(emptyList.Single());
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        } 
    }
}
