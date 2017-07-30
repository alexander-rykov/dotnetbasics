using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using PeopleViewer;
using System.Collections.Generic;

namespace StandardQueryOperators
{
    [TestClass]
    public class ConversionOperators: BaseTestClass
    {
        static void ReportTypeProperties<T>(T obj)
        {
            Console.WriteLine("Compile-time type: {0}", typeof(T).Name);
            Console.WriteLine("Actual type: {0}", obj.GetType().Name);
        }

        [TestMethod]
        public void ConversionOperatorsTestMethod1()
        {
            ReportTypeProperties(personList.ToArray());
            ReportTypeProperties(personList.AsEnumerable());
            ReportTypeProperties(personList.AsQueryable());
            ReportTypeProperties(personList.Cast<Person>());
        }

        [TestMethod]
        public void ConversionOperatorsTestMethod2()
        {
            IDictionary<DateTime, Person> personListDict =
                                personList.ToDictionary<Person, DateTime>(s => s.Birthday);

            foreach (var key in personListDict.Keys)
                Console.WriteLine("Key: {0}, Value: {1}",
                                            key, (personListDict[key] as Person).FirstName);
        }
    }
}
