using System;
using Events_tasks.Models;
using Events_tasks.Observables;

namespace Events_tasks.Observers
{
  public class Bank : IObserver
  {
    public string Name { get; set; }
    IObservable stock;
    public Bank(string name, IObservable obs)
    {
      this.Name = name;
      stock = obs;
      stock.RegisterObserver(this);
    }
    public void Update(object ob)
    {
      StockInfo sInfo = (StockInfo)ob;

      if (sInfo.Euro > 40)
        Console.WriteLine("Банк {0} продает евро;  Курс евро: {1}", this.Name, sInfo.Euro);
      else
        Console.WriteLine("Банк {0} покупает евро;  Курс евро: {1}", this.Name, sInfo.Euro);
    }
  }
}