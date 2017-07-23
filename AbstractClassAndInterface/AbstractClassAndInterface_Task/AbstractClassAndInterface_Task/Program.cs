using AbstractClassAndInterface_Task.FileGenerators;

namespace AbstractClassAndInterface_Task
{
  public class Program
  {
    static void Main(string[] args)
    {
      //TODO: create base abstract class for RandomCharsFileGenerator and RandomBytesFileGenerator

      var filesCount = 1;
      var contentLength = 5;

      new RandomCharsFileGenerator().GenerateFiles(filesCount, contentLength);
      new RandomBytesFileGenerator().GenerateFiles(filesCount, contentLength);
    }
  }
}
