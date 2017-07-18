using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
  //TODO: Refactor this class using anonymous delegates.
  public class AnonymousDelegates
  {
    int[] values = { 4, 5, 6, 7, 3, 4, 1, 0, 4, 7, 8, 5, 4, 7, 5 };

    public int HelperMethod1()
    {
      var sum = 0;

      var fromPage = 1;
      var pageSize = 3;

      var documents = GetDocuments(values, fromPage, pageSize);

      while (documents.Any())
      {
        foreach (var document in documents)
        {
          sum += document * 2;
        }

        documents = GetDocuments(values, ++fromPage, pageSize);
      }

      return sum;
    }

    public int HelperMethod2()
    {
      var sum = 0;

      var fromPage = 1;
      var pageSize = 3;

      var documents = GetDocuments(values, fromPage, pageSize);

      while (documents.Any())
      {
        foreach (var document in documents)
        {
          sum += document * document;
        }

        documents = GetDocuments(values, ++fromPage, pageSize);
      }

      return sum;
    }

    //DO NOT MODIFY THIS METHOD
    public IEnumerable<T> GetDocuments<T>(IEnumerable<T> source, int page, int pageSize)
    {
      var documents = source.Skip((page - 1) * pageSize).Take(pageSize);

      return documents;
    }
  }
}
