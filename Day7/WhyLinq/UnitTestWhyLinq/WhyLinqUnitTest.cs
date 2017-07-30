using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WhyLinq;
using System.Linq;

namespace UnitTestWhyLinq
{
    [TestClass]
    public class WhyLinqUnitTest
    {
        Student[] studentArray = {
            new Student() { StudentID = 1, StudentName = "Albert", Age = 19 },
            new Student() { StudentID = 2, StudentName = "Ivan",  Age = 22 },
            new Student() { StudentID = 3, StudentName = "Plip",  Age = 24 },
            new Student() { StudentID = 4, StudentName = "Sana", Age = 21 },
            new Student() { StudentID = 5, StudentName = "Pol", Age = 30 },
            new Student() { StudentID = 6, StudentName = "Ann",  Age = 18 },
            new Student() { StudentID = 7, StudentName = "Sat", Age = 20  },
        };

        [TestMethod]
        public void TestMethodDotNet10()
        {
            var dotNet10 = new DotNet10();
            var result = dotNet10.GetStudents(studentArray);

            foreach(var item in result)
            {
                Console.WriteLine(item);
            }
        }

        [TestMethod]
        public void TestMethodDotNet20()
        {
            var dotNet20 = new DotNet20();
            var result = dotNet20.GetStudents(studentArray);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        [TestMethod]
        public void TestMethodLinq()
        {
            var result = studentArray.Where(s => s.Age > 12 && s.Age < 20).ToArray();

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
