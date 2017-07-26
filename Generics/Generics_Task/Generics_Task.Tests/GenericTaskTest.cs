using Microsoft.VisualStudio.TestTools.UnitTesting;
using ItemStorage.StorageProvider;
using Generics_Task.BulkProcessing;
using System.Collections.Generic;
using System.Linq;
using CustomFileGenerator;
using System.IO;

namespace Generics_Task.Tests
{
  //TODO: Create base abstract class for BlobBulkMetadataUpdateService and BlobBulkDeleteService using generics
  [TestClass]
  public class GenericTaskTest
  {
    [TestMethod]
    public void TestBulkProcessing()
    {
      var folderName = "Blob Storage";

      Generator.GenerateFiles(folderName);

      var storageProvider = new StorageProvider(folderName);

      var fileNames = storageProvider.GetFileNames();

      this.UpdateMetadataAndTest(storageProvider, fileNames);

      this.DeleteBlobsAndTest(storageProvider, fileNames, folderName);
    }

    private void UpdateMetadataAndTest(IStorageProvider storageProvider, IEnumerable<string> fileNames)
    {
      var blobBulkMetadataUpdateService = new BlobBulkMetadataUpdateService(storageProvider);
      var metaData = new Dictionary<string, string> { { "GonnaDeleteThis", "True" } };

      blobBulkMetadataUpdateService.BulkProcessing(fileNames.Select(fileName => new BlobProcessMetadataContext
      {
        FileName = fileName,
        Metadata = metaData
      }));

      foreach (var fileName in fileNames)
      {
        var obj = storageProvider.GetObject(fileName);
        Assert.IsTrue(obj.Metadata.Count == 1 && obj.Metadata["GonnaDeleteThis"] == "True");
      }
    }

    private void DeleteBlobsAndTest(IStorageProvider storageProvider, IEnumerable<string> fileNames, string folderName)
    {
      var blobBulkDeleteService = new BlobBulkDeleteService(storageProvider);

      blobBulkDeleteService.BulkProcessing(fileNames.Select(fileName => new BlobProcessContext
      {
        FileName = fileName
      }));

      Assert.IsTrue(Directory.EnumerateFiles(folderName).Count() == 0);
    }
  }
}
