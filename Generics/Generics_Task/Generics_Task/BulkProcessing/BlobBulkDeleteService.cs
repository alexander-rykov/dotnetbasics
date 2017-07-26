using System;
using ItemStorage.StorageProvider;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Generics_Task.BulkProcessing
{
  public class BlobProcessContext
  {
    public string FileName { get; set; }
  }

  //TODO: Create base abstract class for BlobBulkMetadataUpdateService and BlobBulkDeleteService using generics
  public class BlobBulkDeleteService
  {
    protected readonly IStorageProvider _storageProvider;

    public BlobBulkDeleteService(IStorageProvider storageProvider)
    {
      _storageProvider = storageProvider;
    }

    public BatchResult BulkProcessing(IEnumerable<BlobProcessContext> processObjects)
    {
      var aggregateResult = new BatchResult();

      var lockList = new object();

      Parallel.ForEach(processObjects, processObject =>
      {
        try
        {
          ProcessFile(processObject);
        }
        catch (Exception e)
        {
          lock (lockList)
          {
            aggregateResult.AddError($"Processing document {processObject.FileName} failed: {e.Message}");
          }
        }
      });

      return aggregateResult;
    }

    public void ProcessFile(BlobProcessContext blobProcessObject)
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