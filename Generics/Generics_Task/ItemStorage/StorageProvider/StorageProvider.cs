using System;
using ItemStorage.Models;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ItemStorage.StorageProvider
{
  public class StorageProvider : IStorageProvider
  {
    public string DirectoryName { get; set; }
    public string FileExtension => ".blob";

    public StorageProvider(string directoryName)
    {
      DirectoryName = directoryName;
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

      var filePath = $"{Guid.NewGuid()}.{this.FileExtension}";

      this.SerializeCustomFile(filePath, file);
    }

    public void DeleteObject(string blobName)
    {
      CheckDirectory();

      var storageFileInfo = this.GetStorageFileInfo(blobName);

      File.Delete(storageFileInfo.FilePath);
    }

    public CustomFile GetObject(string blobName)
    {
      CheckDirectory();

      var storageFileInfo = this.GetStorageFileInfo(blobName);

      return storageFileInfo.CustomFile;
    }

    public void UpdateObject(CustomFile file)
    {
      CheckDirectory();

      var storageFileInfo = this.GetStorageFileInfo(file.BlobName);

      this.SerializeCustomFile(storageFileInfo.FilePath, file);
    }

    public void SerializeCustomFile(string filePath, CustomFile customFile)
    {
      using (var stream = File.Open(GetFullPath(filePath), FileMode.Create))
      {
        var binaryFormatter = new BinaryFormatter();
        binaryFormatter.Serialize(stream, customFile);
      }
    }

    public CustomFile DeserializeCustomFile(string filePath)
    {
      using (var stream = File.Open(filePath, FileMode.Open))
      {
        var binaryFormatter = new BinaryFormatter();
        var customFile = (CustomFile)binaryFormatter.Deserialize(stream);

        return customFile;
      }
    }

    public StorageFileInfo GetStorageFileInfo(string blobName)
    {
      foreach(var filePath in Directory.EnumerateFiles(this.DirectoryName))
      {
        var customFile = this.DeserializeCustomFile(filePath);

        if (customFile.BlobName == blobName)
        {
          return new StorageFileInfo
          {
            FilePath = filePath,
            CustomFile = customFile
          };
        }
      }

      throw new ArgumentException($"Can not find non existing blob ({blobName}).");
    }

    private string GetFullPath(string filePath)
    {
      return $"{this.DirectoryName}//{filePath}";
    }
  }

  public class StorageFileInfo
  {
    public string FilePath { get; set; }

    public CustomFile CustomFile { get; set; }
  }
}
