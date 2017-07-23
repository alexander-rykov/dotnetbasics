using System.Threading.Tasks;

namespace ExceptionHandling_Task
{
  public class ExceptionTask
  {
    public string Content { get; set; }

    public string FileName { get; set; }

    public ExceptionTask(string fileName = "StringFile.txt", string content = "Hello async writer!")
    {
      this.FileName = fileName;
      this.Content = content;
    }

    //TODO: added required try/catch block to handle any possible exceptions and return correct output both to end user and developer (!!!the end user may not understand tech statements or definitions)
    public async Task<string> Launch()
    {
      var stringFileCreater = new StringFileCreater();

      //TODO: add try/catch block here
      await stringFileCreater.WriteStringToFileAsync(FileName, Content);


      //TODO: add try/catch block here
      var contentFromFile = await stringFileCreater.ReadStringFromFileAsync(FileName);

      return contentFromFile;
    }
  }
}
