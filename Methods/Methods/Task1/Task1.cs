using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.IO;

namespace Methods.Task1
{
  public class ExampleClass
  {
    private string _name;

    // Because the parameter for the constructor, name, has a default
    // value assigned to it, it is optional.
    public ExampleClass(string name = "Default name")
    {
      _name = name;
    }

    // The first parameter, required, has no default value assigned
    // to it. Therefore, it is not optional. Both optionalstr and 
    // optionalint have default values assigned to them. They are optional.
    public string ExampleMethod(int required, string optionalstr = "default string",
        int optionalint = 10)
    {
      return string.Format("{0}: {1}, {2}, and {3}.", _name, required, optionalstr, optionalint) + "\r\n";
    }
  }

  [TestClass]
  public class Task1
  {
    public string Execute()
    {
      var result = new StringBuilder();

      ExampleClass anExample = new ExampleClass();
      result.Append(anExample.ExampleMethod()); // Default name: 1, One, and 1.
      result.Append(anExample.ExampleMethod()); // Default name: 2, Two, and 10.
      result.Append(anExample.ExampleMethod()); // Default name: 3, default string, and 10.

      ExampleClass anotherExample = new ExampleClass();
      result.Append(anotherExample.ExampleMethod()); // Provided name: 1, One, and 1.
      result.Append(anotherExample.ExampleMethod()); // Provided name: 2, Two, and 10.
      result.Append(anotherExample.ExampleMethod()); // Provided name: 3, default string, and 10.

      result.Append(anExample.ExampleMethod()); // Default name: 3, default string, and 4.

      return result.ToString();
    }

    [TestMethod]
    public void Methods_Named_Opt_Task1()
    {
      //TODO: You should change "ExampleMethod" calls from "Execute" using named and optional parameters to make test successfully completed.

      var expextedResult = File.ReadAllText("result.txt");

      var actual = Execute();

      var result = string.Compare(expextedResult, actual);

      Assert.IsTrue(result == 0);
    }
  }
}
