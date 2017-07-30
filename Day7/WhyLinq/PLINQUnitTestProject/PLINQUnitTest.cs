using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Diagnostics;

namespace PLINQUnitTestProject
{
    [TestClass]
    public class PLINQUnitTest
    {
        string[] cars = { "Nissan", "Aston Martin", "Chevrolet", "Alfa Romeo", "Chrysler", "Dodge", "BMW",
                              "Ferrari", "Audi", "Bentley", "Ford", "Lexus", "Mercedes", "Toyota", "Volvo", "Subaru", "Lada"};

        [TestMethod]
        public void PLINQTestMethod1()
        {
            string auto = cars.Where(p => p.StartsWith("S")).First();
            Console.WriteLine(auto);

            auto = cars.AsParallel()
               .Where(p => p.StartsWith("S")).First();
            Console.WriteLine(auto);
        }

        [TestMethod]
        public void PLINQTestMethod2()
        {
            var nums1 = Enumerable.Range(0, Int32.MaxValue);
            var sw = Stopwatch.StartNew();

            int sum1 = nums1.Count(n => n % 2 == 0);

            Console.WriteLine("Result: " + sum1 +
                "\nTime: " + sw.ElapsedMilliseconds + " ms\n");

            var nums2 = ParallelEnumerable.Range(0, Int32.MaxValue);
            sw.Restart();
            int sum2 = nums2.AsParallel().Count(n => n % 2 == 0);

            Console.WriteLine("Result: " + sum2 +
                "\nTime: " + sw.ElapsedMilliseconds + " ms");
        }

        [TestMethod]
        public void PLINQTestMethod3()
        {
            var auto = cars
                .Select(p =>
                {
                    if (p == "Aston Martin")
                        throw new Exception("Problem with car " + p);
                    return p;
                });

            try
            {
                foreach (string s in auto)
                    Console.WriteLine("Результат: " + s + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [TestMethod]
        public void PLINQTestMethod4()
        {
            var auto = cars
               .AsParallel()
               .Select(p =>
               {
                   if (p == "Aston Martin" || p == "Ford")
                       throw new Exception("Preblems with car " + p);
                   return p;
               });

            try
            {
                foreach (string s in auto)
                    Console.WriteLine("Result: " + s + "\n");
            }
            catch (AggregateException agex)
            {
                agex.Handle(ex =>
                {
                    Console.WriteLine(ex.Message);
                    return true;
                });
            }
        }

        [TestMethod]
        public void PLINQTestMethod5()
        {
            cars.AsParallel()
                .Where(p => p.Contains("s"))
                .ForAll(p => Console.WriteLine("Name: " + p));
        }
    }
}
