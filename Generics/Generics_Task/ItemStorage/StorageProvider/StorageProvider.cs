using System;
using ItemStorage.Models;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Linq;

namespace ItemStorage.StorageProvider
{
  public class StorageProvider : IStorageProvider
  {
    private class StorageFileInfo
    {
      public string FilePath { get; set; }

      public string BlobName { get; set; }

      public override string ToString()
      {
        return $"{this.FilePath} - {this.BlobName}";
      }
    }

    public string DirectoryName { get; set; }
    public string FileExtension => ".blob";

    private List<StorageFileInfo> Indexes { get; set; }

    public StorageProvider(string directoryName)
    {
      DirectoryName = directoryName;
      Indexes = this.GetIndexes();
    }

    public void CheckDirectory()
    {
      if (Directory.Exists(DirectoryName) == false)
      {
        Directory.CreateDirectory(DirectoryName);
      }
    }

    public void AddObject(CustomFile file)
    {
      CheckDirectory();

      var filePath = $"{Guid.NewGuid()}{this.FileExtension}";

      this.SerializeCustomFile(filePath, file);
      this.Indexes.Add(new StorageFileInfo
      {
        FilePath = filePath,
        BlobName = file.BlobName
      });
    }

    public void DeleteObject(string blobName)
    {
      CheckDirectory();

      var storageFileInfo = this.GetStorageFileInfo(blobName);

      File.Delete(storageFileInfo.FilePath);
      this.Indexes.Remove(this.Indexes.SingleOrDefault(item => item.BlobName == blobName));
    }

    public CustomFile GetObject(string blobName)
    {
      CheckDirectory();

      var storageFileInfo = this.GetStorageFileInfo(blobName);

      var customFile = this.DeserializeCustomFile(storageFileInfo.FilePath);

      return customFile;
    }

    public void UpdateObject(CustomFile file)
    {
      CheckDirectory();

      var storageFileInfo = this.GetStorageFileInfo(file.BlobName);

      this.SerializeCustomFile(storageFileInfo.FilePath, file);
    }

    public string[] GetFileNames()
    {
      return this.Indexes.Select(item => item.BlobName).ToArray();
    }

    private void SerializeCustomFile(string filePath, CustomFile customFile)
    {
      using (var stream = File.Open(GetFullPath(filePath), FileMode.Create))
      {
        var binaryFormatter = new BinaryFormatter();
        binaryFormatter.Serialize(stream, customFile);
      }
    }

    private CustomFile DeserializeCustomFile(string filePath)
    {
      using (var stream = File.Open(filePath, FileMode.Open))
      {
        var binaryFormatter = new BinaryFormatter();
        var customFile = (CustomFile)binaryFormatter.Deserialize(stream);

        return customFile;
      }
    }

    private StorageFileInfo GetStorageFileInfo(string blobName)
    {
      var info = this.Indexes.FirstOrDefault(item => item.BlobName == blobName);

      if (info != null)
      {
        return info;
      }

      throw new ArgumentException($"Can not find non existing blob ({blobName}).");
    }

    private List<StorageFileInfo> GetIndexes()
    {
      var indexes = new List<StorageFileInfo>();

      foreach (var filePath in Directory.EnumerateFiles(this.DirectoryName))
      {
        var customFile = this.DeserializeCustomFile(filePath);

        indexes.Add(new StorageFileInfo
        {
          FilePath = Path.GetFileName(filePath),
          BlobName = customFile.BlobName
        });
      }

      return indexes;
    }

    private string GetFullPath(string filePath)
    {
      return $"{this.DirectoryName}//{filePath}";
    }
  }

  
}
