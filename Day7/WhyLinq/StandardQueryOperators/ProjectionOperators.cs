using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace StandardQueryOperators
{
    [TestClass]
    public class ProjectionOperators : BaseTestClass
    {
        [TestMethod]
        public void ProjectionOperatorsMethod1()
        {
            var result = personList.Select(e =>  new { Name = $"Mr./Ms. {e.FirstName} {e.LastName}", Age =  (int)((DateTime.Now - e.Birthday).Days / 365.2425) });

            foreach (var item in result)
                Console.WriteLine(item);
        }
    }
}
