using System;
using System.Collections.Generic;
using ItemStorage.StorageProvider;
using System.Threading.Tasks;

namespace Generics_Task.BulkProcessing
{
  public class BlobProcessMetadataContext
  {
    public string FileName { get; set; }
    public Dictionary<string, string> Metadata { get; set; }
  }

  //TODO: Create base abstract class for BlobBulkMetadataUpdateService and BlobBulkDeleteService using generics
  public class BlobBulkMetadataUpdateService
  {
    protected readonly IStorageProvider _storageProvider;

    public BlobBulkMetadataUpdateService(IStorageProvider storageProvider)
    {
      _storageProvider = storageProvider;
    }

    public BatchResult BulkProcessing(IEnumerable<BlobProcessMetadataContext> processObjects)
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

    public void ProcessFile(BlobProcessMetadataContext processObject)
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