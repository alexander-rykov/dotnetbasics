using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace StandardQueryOperators
{
    [TestClass]
    public class SortingOperators : BaseTestClass
    {  
        [TestMethod]
        public void SortingOperatorsMethod1()
        {
            var result = personList.OrderByDescending(s => s.LastName);

            foreach (var item in result)
                Console.WriteLine(item);
        }

        [TestMethod]
        public void SortingOperatorsMethod2()
        {
            var result = personList.OrderBy(s => s.Salary);

            foreach (var item in result)
                Console.WriteLine(item);
        }

        [TestMethod]
        public void SortingOperatorsMethod3()
        {
            var result = personList.OrderBy(s => s.FirstName).ThenBy(ns => ns.LastName).ThenByDescending(nns => nns.Salary);

            foreach (var item in result)
                Console.WriteLine(item);
        }
    }
}
