using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Strongly_Typed_Delegates_Task1
{
    [TestClass]
    public class StronglyTypedDelegatesTests
    {
        [TestMethod]
        public void StronglyTypedDelegatesTestMethod1()
        {
            var stringList = new List<string> {"abc", "dsr", "qdqwdqw", "sss", "ekhk", "ddq"};

            var expectedResult = new List<string> { "abc", "dsr", "sss", "ddq" };

            var actual = SortHelper.GetStringsWithSpecifiedLength(stringList, 3);

            var equal = actual.SequenceEqual(expectedResult);

            Assert.IsTrue(equal);
        }
    }
}
