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

      using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Write))
      {
        var bytes = Encoding.Unicode.GetBytes(content);

        await stream.WriteAsync(bytes, 0, bytes.Length);
      }
    }

    public async Task<string> ReadStringFromFileAsync(string filePath)
    {
      using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
      {
        var count = stream.Length;

        var bytes = new byte[count];

        await stream.ReadAsync(bytes, 0, (int)count);

        var content = Encoding.Unicode.GetString(bytes);

        return content;
      }
    }
  }
}
