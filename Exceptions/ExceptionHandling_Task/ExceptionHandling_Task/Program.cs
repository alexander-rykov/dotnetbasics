using System;
using System.Threading.Tasks;

namespace ExceptionHandling_Task
{
  class Program
  {
    static void Main(string[] args)
    {
      MainAsync(args).Wait();
    }

    static async Task MainAsync(string[] args)
    {
      var exceptionTask = new ExceptionTask();

      try
      {
        var output = await exceptionTask.Launch();

        Console.WriteLine(output);
      }
      catch(Exception e)
      {
        Console.WriteLine($"User message: {e.Message}");
        Console.WriteLine($"Message for developers: {e.ToString()}");
      }
    }
  }

}
