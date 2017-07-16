using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Methods.Task2
{
  [TestClass]
  public class Task1
  {
    public void Execute(string first, string second)
    {
      Console.Write("Hello world!!! => {0} => {1} => {2}", first, second, third);
    }

    [TestMethod]
    public void Methods_Named_Opt_Task2()
    {
      //TODO: You should change "Execute" method signature using optional parameters to make test successfully completed.

      this.SomeMethodCallsFromProd();

      this.Execute(".NET", "LAB", "best");
    }

    //DO NOT MODIFY THIS METHOD
    public void SomeMethodCallsFromProd()
    {
      this.Execute(".NET", "LAB");
      this.Execute(".NET", "LAB");
      this.Execute(".NET", "LAB");
      this.Execute(".NET", "LAB");
      this.Execute(".NET", "LAB");
      this.Execute(".NET", "LAB");
      this.Execute(".NET", "LAB");
      this.Execute(".NET", "LAB");
      this.Execute(".NET", "LAB");
      this.Execute(".NET", "LAB");
      this.Execute(".NET", "LAB");
      this.Execute(".NET", "LAB");
      this.Execute(".NET", "LAB");
      this.Execute(".NET", "LAB");
      this.Execute(".NET", "LAB");
      this.Execute(".NET", "LAB");
      this.Execute(".NET", "LAB");
      this.Execute(".NET", "LAB");
    }
  }
}
