using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling_Task
{
  public class StringFileCreater
  {
    public async Task WriteStringToFileAsync(string filePath, string content)
    {
      //TODO: create custom type exception and throw it when content parameter is empty string or null

      FileStream stream = null;


      //TODO avoid try/catch usage here by "using" operator usage
      try
      {
        stream = new FileStream(filePath, FileMode.Open, FileAccess.Write);

        var bytes = Encoding.Unicode.GetBytes(content);

        await stream.WriteAsync(bytes, 0, bytes.Length);
      }
      finally
      {
        if (stream != null)
        {
          stream.Dispose();
        }
      }
    }

    public async Task<string> ReadStringFromFileAsync(string filePath)
    {
      FileStream stream = null;

      //TODO avoid try/catch usage here by "using" operator usage
      try
      {
        stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

        var count = stream.Length;

        var bytes = new byte[count];

        await stream.ReadAsync(bytes, 0, (int)count);

        var content = Encoding.Unicode.GetString(bytes);

        return content;
      }
      finally
      {
        if (stream != null)
        {
          stream.Dispose();
        }
      }
    }
  }
}
