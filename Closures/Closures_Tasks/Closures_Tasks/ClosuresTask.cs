using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Closures_Tasks
{
  class Program
  {
    static void Main(string[] args)
    {
      var closuresTask = new ClosuresTask();

      var stopWatch = new Stopwatch();
      stopWatch.Start();

      closuresTask.Start();

      stopWatch.Stop();
      var elapsed = stopWatch.Elapsed;
      var elapsedTime = $"{elapsed.Hours:00}:{elapsed.Minutes:00}:{elapsed.Seconds:00}.{elapsed.Milliseconds / 10:00}";

      Console.WriteLine($"Required time: {elapsedTime}");
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

      // Imitation of hard work (e.g. call to remote service to get some data)
      Thread.Sleep(TimeSpan.FromSeconds(2));

      var value = random.Next(1, 10);
      if (value > 6)
      {
        throw new Exception($"Processing item \"{item}\" failed cause random value is {value}.");
      }
    }
  }
}
