using System;
using ItemStorage.StorageProvider;

namespace Generics_Task.BulkProcessing
{
  public class BlobBulkDeleteService : BlobBulkProcessing<BlobProcessContext>
  {
    public BlobBulkDeleteService(IStorageProvider azureBlobStreamStore) : base(azureBlobStreamStore) { }
    protected override void ProcessFile(BlobProcessContext blobProcessObject)
    {
      try
      {
        _storageProvider.DeleteObject(blobProcessObject.FileName);
      }
      catch (Exception e)
      {
        throw new AggregateException($"Error while deleting document {blobProcessObject.FileName}", e);
      }
    }
  }
}