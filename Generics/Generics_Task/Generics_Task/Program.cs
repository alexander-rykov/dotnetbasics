using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generics_Task.BulkProcessing;
using ItemStorage.Models;
using ItemStorage.StorageProvider;

namespace Generics_Task
{
  class Program
  {
    static void Main(string[] args)
    {
      var storageProvider = new StorageProvider("Blob Storage");

      var fileNames = storageProvider.GetFileNames();

      var blobBulkMetadataUpdateService = new BlobBulkMetadataUpdateService(storageProvider);
      var metaData = new Dictionary<string, string> { { "GonnaDeleteThis", "True" } };

      blobBulkMetadataUpdateService.BulkProcessing(fileNames.Select(fileName => new BlobProcessMetadataContext
      {
        FileName = fileName,
        Metadata = metaData
      }));

      var obj = storageProvider.GetObject(fileNames[0]);

      var blobBulkDeleteService = new BlobBulkDeleteService(storageProvider);

      blobBulkDeleteService.BulkProcessing(fileNames.Select(fileName => new BlobProcessContext
      {
        FileName = fileName
      }));
    }

  }
}
