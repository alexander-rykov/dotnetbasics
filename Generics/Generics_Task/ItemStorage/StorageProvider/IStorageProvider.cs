using ItemStorage.Models;

namespace ItemStorage.StorageProvider
{
  public interface IStorageProvider
  {
    CustomFile GetObject(string FileName);

    void AddObject(CustomFile file);

    void UpdateObject(CustomFile file);

    void DeleteObject(string FileName);

    string[] GetFileNames();
  }
}
