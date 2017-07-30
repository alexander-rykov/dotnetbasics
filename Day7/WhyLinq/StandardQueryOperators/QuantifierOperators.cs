using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeopleViewer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StandardQueryOperators
{
    [TestClass]
    public class QuantifierOperators : BaseTestClass
    {
        [TestMethod]
        public void QuantifierOperatorsTestMethod0()
        {
            var result = personList.All(s => s.Salary > 12000 && s.Salary < 20000);
            Assert.IsFalse(result);

            result = personList.All(s => s.Salary > 2000 && s.Salary < 40000);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void QuantifierOperatorsTestMethod1()
        {
            var result = personList.Any(s => s.Salary > 12000 && s.Salary < 20000);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void QuantifierOperatorsTestMethod2()
        {
            var intList = new List<int>() { 1, 2, 3, 4, 5 };

            bool result = intList.Contains(10);
            Assert.IsFalse(result);

            result = intList.Contains(4);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void QuantifierOperatorsTestMethod3()
        {
            var prs = new Person()
            {
                FirstName = "Anna",
                LastName = "Stil",
                Birthday = new DateTime(1998, 11, 3),
                Status = 9,
                Salary = 10120
            };
            var result = personList.Contains(prs);

            Assert.IsTrue(result);
        }
    }
}
