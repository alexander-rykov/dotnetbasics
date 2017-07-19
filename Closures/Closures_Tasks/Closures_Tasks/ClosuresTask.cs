using System;
using System.Linq;
using System.Threading.Tasks;

namespace Closures_Tasks
{
  class Program
  {
    static void Main(string[] args)
    {
      var closuresTask = new ClosuresTask();

      closuresTask.Start();
    }
  }

  //TODO: rewrite ClosureTask class using closures by avoiding "ClosureTaskHelper" class usage (just delete it).
  public class ClosuresTask
  {
    private sealed class ClosureTaskHelper
    {
      public object lockObject = new object();

      public BatchResult aggregateResult = new BatchResult();

      public void Launch(int item)
      {
        try
        {
          ProcessorHelper.Process(item);
        }
        catch (Exception ex)
        {
          lock (lockObject)
          {
            this.aggregateResult.AddError(ex.Message);
          }
        }
      }
    }

    public void Start()
    {
      var items = Enumerable.Range(1, 100);

      var context = new ClosureTaskHelper();
      
      Parallel.ForEach(items, new Action<int>(context.Launch));

      if (context.aggregateResult.Success == false)
      {
        Console.WriteLine(string.Join("\n", context.aggregateResult.Errors));
      }      
    }
  }

  public static class ProcessorHelper
  {
    public static Random random = new Random();

    public static void Process(int item)
    {
      // processing the item (e.g. sending its value to the specified service)

      var value = random.Next(1, 10);
      if (value > 6)
      {
        throw new Exception($"Processing item \"{item}\" failed cause random value is {value}.");
      }
    }
  }
}
