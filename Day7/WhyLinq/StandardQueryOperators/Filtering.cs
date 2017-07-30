using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections;

namespace StandardQueryOperators
{
    [TestClass]
    public class Filtering : BaseTestClass
    {
        [TestMethod]
        public void FilteringMethod1()
        {
            var result = personList.Where(p => p.Salary > 12000);
            Assert.AreEqual(result.Count(), 4);
        }

        [TestMethod]
        public void FilteringMethod2()
        {
            var result = personList.Where(p => p.Salary > 12000 && p.Birthday < new DateTime(1980, 1, 1));
            Assert.AreEqual(result.Count(), 3);
        }

        [TestMethod]
        public void FilteringMethod3()
        {
            var result = personList.Where(p => p.Salary > 12000 && p.Birthday < new DateTime(1980, 1, 1))
                .Where(e => e.FirstName == "Robert");
            Assert.AreEqual(result.Count(), 1);
        }

        [TestMethod]
        public void FilteringMethod4()
        {
            var mixedList = new ArrayList
            {
                0, "One", "Two", 3, 4.5, true,
                new { ID = 1, Name = "Tom" }
            };

            var stringResult = mixedList.OfType<string>();
            foreach (var item in stringResult)
                Console.WriteLine(item);

            var intResult = mixedList.OfType<int>();
            foreach (var item in intResult)
                Console.WriteLine(item);
        }
    }
}
