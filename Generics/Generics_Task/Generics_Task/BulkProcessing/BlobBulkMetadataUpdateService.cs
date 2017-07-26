using System;
using System.Collections.Generic;
using ItemStorage.StorageProvider;

namespace Generics_Task.BulkProcessing
{
  public class BlobProcessMetadataContext : BlobProcessContext
  {
    public Dictionary<string, string> Metadata { get; set; }
  }

  public class BlobBulkMetadataUpdateService : BlobBulkProcessing<BlobProcessMetadataContext>
  {
    public BlobBulkMetadataUpdateService(IStorageProvider azureBlobStreamStore) : base(azureBlobStreamStore) { }

    protected override void ProcessFile(BlobProcessMetadataContext processObject)
    {
      try
      {
        _storageProvider.UpdateObjectMetadata(processObject.FileName, processObject.Metadata);
      }
      catch (Exception e)
      {
        throw new Exception($"Metadata update on blob {processObject.FileName} failed.", e);
      }
    }
  }
}