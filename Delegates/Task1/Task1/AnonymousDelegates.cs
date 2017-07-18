using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task1
{
  [TestClass]
  public class AnonymousDelegates
  {
    [TestMethod]
    public void AnonymousDelegatesTestMethod()
    {
      var someHelper = new SomeHelper();

      Console.WriteLine(someHelper.HelperMethod1());
      Console.WriteLine(someHelper.HelperMethod2());
    }
  }
}
