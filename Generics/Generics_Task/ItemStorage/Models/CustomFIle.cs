using System;
using System.Collections.Generic;

namespace ItemStorage.Models
{
  [Serializable]
  public class CustomFile
  {
    public CustomFile(string fileName, byte[] Content)
    {
      this.BlobName = fileName;
      this.Content = Content;
      Metadata = new Dictionary<string, string>();
    }

    public string BlobName { get; set; }
    public byte[] Content { get; set; }
    public Dictionary<string, string> Metadata { get; set; }
  }
}
