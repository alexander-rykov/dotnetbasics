using System;

namespace ConsoleApp1
{
  class Example
  {
    static void Main()
    {
      var bc = new BookCollection();
      bc.ListBooks();

      ref var book = ref bc.GetBookByTitle("Call of the Wild, The"); // ref local

      book = new Book { Title = "Republic, The", Author = "Plato" };
      bc.ListBooks();
    }
  }

  public struct Book
  {
    public string Author;
    public string Title;
  }

  public class BookCollection
  {
    private Book[] books = { new Book { Title = "Call of the Wild, The", Author = "Jack London" },
                            new Book { Title = "Tale of Two Cities, A", Author = "Charles Dickens" }
                           };
    private Book nobook = new Book { Title = "No such book" };

    public ref Book GetBookByTitle(string title) // ref return 
    {
      for (int ctr = 0; ctr < books.Length; ctr++)
      {
        if (title == books[ctr].Title)
          return ref books[ctr];
      }

      return ref nobook;
    }

    public void ListBooks()
    {
      foreach (var book in books)
      {
        Console.WriteLine($"{book.Title}, by {book.Author}");
      }
      Console.WriteLine();
    }
  }
}