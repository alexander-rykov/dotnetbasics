using ItemStorage.Models;
using ItemStorage.StorageProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomFileGenerator
{
  public class Generator
  {
    static void Main(string[] args)
    {
      GenerateFiles(@"..\..\..\Generics_Task\bin\Debug\Blob Storage");
    }

    public static void GenerateFiles(string path)
    {
      var contentSize = 10;
      var filesCount = 10;

      var files = new List<CustomFile>();
      for (var i = 0; i < filesCount; ++i)
      {
        files.Add(CustomTextFileGenerator.GenerateLargeTestFile(contentSize));
      }

      var storage = new StorageProvider(path);

      string fileName = null;

      foreach (var file in files)
      {
        storage.AddObject(file);
        fileName = file.BlobName;
      }
    }
  }

  public class CustomTextFileGenerator
  {
    public static CustomFile GenerateLargeTestFile(int contentSize)
    {
      var generatedString = RandomString(contentSize);

      var fileContent = Encoding.Unicode.GetBytes(generatedString);

      var customFile = new CustomFile(Guid.NewGuid() + ".testfile", fileContent);

      return customFile;
    }

    private static string RandomString(int Size)
    {
      var random = new Random();

      const string input = "abcdefghijklmnopqrstuvwxyz0123456789";
      var chars = Enumerable.Range(0, Size)
                             .Select(x => input[random.Next(0, input.Length)]);
      return new string(chars.ToArray());
    }
  }
}