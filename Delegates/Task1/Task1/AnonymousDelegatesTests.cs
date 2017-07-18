using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task1
{
    [TestClass]
    public class AnonymousDelegatesTests
    {
        [TestMethod]
        public void AnonymousDelegatesTestMethod()
        {
            var someHelper = new AnonymousDelegates();

            Assert.AreEqual(140, someHelper.HelperMethod1());
            Assert.AreEqual(396, someHelper.HelperMethod2());
        }
    }
}
