using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using PeopleViewer;

namespace StandardQueryOperators
{
    [TestClass]
    public class AggregationOperators : BaseTestClass
    {
        [TestMethod]
        public void AggregationOperatorsTestMethod1()
        {
            var strList = new List<string>() { "One", "Two", "Three", "Four", "Five" };

            var commaSeperatedString = strList.Aggregate((s1, s2) => s1 + ", " + s2);

            Console.WriteLine(commaSeperatedString);
        }

        [TestMethod]
        public void AggregationOperatorsTestMethod2()
        {
            var result = personList.Aggregate<Person, decimal>(0, (total, s) => total += s.Salary);

            Assert.AreEqual(114570, result);
        }

        [TestMethod]
        public void AggregationOperatorsTestMethod3()
        {
            var intList = new List<int> () { 10, 20, 30, 15 };

            var avg = intList.Average();

            Console.WriteLine("Average: {0}", avg);
        }

        [TestMethod]
        public void AggregationOperatorsTestMethod4()
        {
            var result = personList.Average(p => p.Salary);

            Assert.AreEqual(12730, result);
        }

        [TestMethod]
        public void AggregationOperatorsTestMethod5()
        {
            var result = personList.Count();

            Assert.AreEqual(9, result);

            result = personList.Count(p => p.Salary >= 12000);
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void AggregationOperatorsTestMethod6()
        {
            var maxSalary = personList.Max(p => p.Salary);
            Assert.AreEqual(22000, maxSalary);
        }

        [TestMethod]
        public void AggregationOperatorsTestMethod7()
        {
            var maxSalary = personList.Sum(p => p.Salary);
            Assert.AreEqual(114570, maxSalary);
        }
    }
}
