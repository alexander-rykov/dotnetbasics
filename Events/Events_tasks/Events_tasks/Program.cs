using System;
using System.Collections.Generic;
using Events_tasks.Observables;
using Events_tasks.Observers;

namespace Events_tasks
{
  //TODO: update the code using .net events
  class Program
  {
    static void Main(string[] args)
    {
      Stock stock = new Stock();
      Bank bank = new Bank("ЮнитБанк", stock);
      Broker broker = new Broker("Иван Иваныч", stock);
      // имитация торгов
      stock.Market();
      // брокер прекращает наблюдать за торгами
      broker.StopTrade();
      // имитация торгов
      stock.Market();

      Console.Read();
    }
  }
}
