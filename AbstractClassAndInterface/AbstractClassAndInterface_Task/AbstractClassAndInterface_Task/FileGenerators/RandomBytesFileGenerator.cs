using System;
using System.IO;

namespace AbstractClassAndInterface_Task.FileGenerators
{
  public class RandomBytesFileGenerator
  {
    public string WorkingDirectory => "Files with random bytes";

    public string FileExtension => ".bytes";

    private byte[] GenerateFileContent(int contentLength)
    {
      var random = new Random();

      var fileContent = new byte[contentLength];

      random.NextBytes(fileContent);

      return fileContent;
    }

    public void GenerateFiles(int filesCount, int contentLength)
    {
      for (var i = 0; i < filesCount; ++i)
      {
        var generatedFileContent = this.GenerateFileContent(contentLength);
        var generatedFileName = $"{Guid.NewGuid()}{this.FileExtension}";

        this.WriteBytesToFile(generatedFileName, generatedFileContent);
      }
    }

    private void WriteBytesToFile(string fileName, byte[] content)
    {
      if (Directory.Exists(WorkingDirectory) == false)
      {
        Directory.CreateDirectory(WorkingDirectory);
      }

      File.WriteAllBytes($"{WorkingDirectory}//{fileName}", content);
    }
  }
}
