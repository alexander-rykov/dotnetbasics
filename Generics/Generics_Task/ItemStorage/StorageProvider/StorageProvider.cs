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
      public string PhysicalFileName { get; set; }

      public string BlobName { get; set; }

      public override string ToString()
      {
        return $"{this.PhysicalFileName} - {this.BlobName}";
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
        PhysicalFileName = filePath,
        BlobName = file.BlobName
      });
    }

    public void DeleteObject(string blobName)
    {
      CheckDirectory();

      var storageFileInfo = this.GetStorageFileInfo(blobName);

      File.Delete(this.GetFullPath(storageFileInfo.PhysicalFileName));
      this.Indexes.Remove(this.Indexes.SingleOrDefault(item => item.BlobName == blobName));
    }

    public void UpdateObjectMetadata(string blobName, IDictionary<string, string> metaData)
    {
      var storageFileInfo = this.GetObject(blobName);

      storageFileInfo.Metadata.Clear();

      foreach (var key in metaData.Keys)
      {
        storageFileInfo.Metadata.Add(key, metaData[key]);
      }

      this.UpdateObject(storageFileInfo);
    }

    public CustomFile GetObject(string blobName)
    {
      CheckDirectory();

      var storageFileInfo = this.GetStorageFileInfo(blobName);

      var customFile = this.DeserializeCustomFile(storageFileInfo.PhysicalFileName);

      return customFile;
    }

    public void UpdateObject(CustomFile file)
    {
      CheckDirectory();

      var storageFileInfo = this.GetStorageFileInfo(file.BlobName);

      this.SerializeCustomFile(storageFileInfo.PhysicalFileName, file);
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
      using (var stream = File.Open(GetFullPath(filePath), FileMode.Open))
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
      CheckDirectory();

      var indexes = new List<StorageFileInfo>();

      foreach (var filePath in Directory.EnumerateFiles(this.DirectoryName))
      {
        var fileName = Path.GetFileName(filePath);

        var customFile = this.DeserializeCustomFile(fileName);

        indexes.Add(new StorageFileInfo
        {
          PhysicalFileName = fileName,
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
