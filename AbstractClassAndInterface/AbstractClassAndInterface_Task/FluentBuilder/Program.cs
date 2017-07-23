using FluentBuilder.Builders;
using System;
using System.ComponentModel;

namespace FluentBuilder
{
  //source article here: https://nesteruk.wordpress.com/2010/08/25/fluent-builder-in-csharp/

  class Program
  {
    static void Main(string[] args)
    {
      Person me = Person.Create().Called("Ivan").Age(25)
        .Lives.At("123 London Road").WithPostCode("SO17 1BJ").In("Southampton")
        .Works.At("CRSI").AsA("VisitingResearcher").Earning(12345);

      PrintProps(me);
    }

    public static void PrintProps(object obj)
    {
      foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(obj))
      {
        string name = descriptor.Name;
        object value = descriptor.GetValue(obj);
        Console.WriteLine("{0}={1}", name, value);
      }
    }
  }
}
