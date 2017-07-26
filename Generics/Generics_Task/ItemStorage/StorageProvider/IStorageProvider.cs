using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using ItemStorage.Models;

namespace ItemStorage.StorageProvider
{
  public interface IStorageProvider
  {
    CustomFile GetObject(string blobName);

    void AddObject(CustomFile file);

    void UpdateObject(CustomFile file);

    void DeleteObject(string blobName);

    void UpdateObjectMetadata(string blobName, IDictionary<string, string> metaData);

    string[] GetFileNames();
  }
}
