using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Linq;
using System.Linq;

namespace LinqToXML
{
    [TestClass]
    public class LINQToXMLUnitTest
    {
        private readonly string path = "TestData.xml";


        [TestMethod]
        public void GetXMLData()
        {
            try
            {
                var testXML = XDocument.Load(path);
                var students = from student in testXML.Descendants("Student")
                               select new
                               {
                                   ID = Convert.ToInt32(student.Attribute("ID").Value),
                                   Name = student.Element("Name").Value,
                                   Salary = student.Element("Salary").Value
                               };

                foreach (var student in students)
                {
                    Console.WriteLine(student);
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                Assert.Fail();
            }
        }

        [TestMethod]
        public void InsertXMLData()
        {
            try
            {
                var rnd = new Random();
                XDocument testXML = XDocument.Load(path);

                var lastStudent = testXML.Descendants("Student").Last();

                int newID = Convert.ToInt32(lastStudent.Attribute("ID").Value)+1;

                XElement newStudent = new XElement("Student", new XElement("Name", $"Test{newID}"), new XElement("Salary", 11000));

                newStudent.SetAttributeValue("ID", newID++);
                testXML.Element("Students").Add(newStudent);
                testXML.Save(path);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                Assert.Fail();
            }
        }

        [TestMethod]
        public void UpdateXMLData()
        {
            string name = "NewTest3";
            int id = 3;
            try
            {
                XDocument testXML = XDocument.Load(path);
                XElement cStudent = testXML.Descendants("Student").Where(c => c.Attribute("ID").Value.Equals(id.ToString())).FirstOrDefault();

                cStudent.Element("Name").Value = name;
                testXML.Save(path);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                Assert.Fail();
            }
        }

        [TestMethod]
        public void DeleteXMLData()
        {
            int id = 2;
            try
            {
                XDocument testXML = XDocument.Load(path);
                XElement cStudent = testXML.Descendants("Student").Where(c => c.Attribute("ID").Value.Equals(id.ToString())).FirstOrDefault();
                cStudent.Remove();
                testXML.Save(path);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                Assert.Fail();
            }
        }
    }
}
