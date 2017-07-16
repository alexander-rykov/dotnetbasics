using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Methods_Ref_Out_ReturningMultipleObjects_Task1
{
  public class HelperModel { public string Field = "Field"; }

  [TestClass]
  public class UnitTest1
  {
    // Modify this method by using ref/out
    public void RefOutMethod(out string first, out HelperModel second, out int third)
    {
      var WannaSeeThisValueInOutput1 = "Test1";
      var WannaSeeThisValueInOutput2 = new HelperModel();
      var WannaSeeThisValueInOutput3 = 4;

      first = WannaSeeThisValueInOutput1;
      second = WannaSeeThisValueInOutput2;
      third = WannaSeeThisValueInOutput3;
    }

    public void RefOutMethodCall()
    {
      //TODO: print the values from RefOutMethod using ref/out

      Print(WannaSeeThisValueInOutput1, WannaSeeThisValueInOutput2, WannaSeeThisValueInOutput3);
    }

    // Modify this method by using class
    public void ClassMethod()
    {
      var WannaSeeThisValueInOutput1 = "Test1";
      var WannaSeeThisValueInOutput2 = new HelperModel();
      var WannaSeeThisValueInOutput3 = 4;
    }

    public void ClassMethodCall()
    {
      //TODO: print the values from ClassMethod using class

      Print(WannaSeeThisValueInOutput1, WannaSeeThisValueInOutput2, WannaSeeThisValueInOutput3);
    }

    // Modify this method by using tuple
    public void TupleMethod()
    {
      var WannaSeeThisValueInOutput1 = "Test1";
      var WannaSeeThisValueInOutput2 = new HelperModel();
      var WannaSeeThisValueInOutput3 = 4;
    }

    public void TupleMethodCall()
    {
      //TODO: print the values from TupleMethod using tuple

      Print(WannaSeeThisValueInOutput1, WannaSeeThisValueInOutput2, WannaSeeThisValueInOutput3);
    }

    [TestMethod]
    public void Methods_Ref_Out_ReturningMultipleObjects_Task1()
    {
      RefOutMethodCall();
      ClassMethodCall();
      TupleMethodCall();
    }

    public void Print(string WannaSeeThisValueInOutput1, HelperModel WannaSeeThisValueInOutput2, int WannaSeeThisValueInOutput3)
    {
      Console.WriteLine($"{WannaSeeThisValueInOutput1}, {WannaSeeThisValueInOutput2.Field}, {WannaSeeThisValueInOutput3.ToString()}");
    }
  }
}
