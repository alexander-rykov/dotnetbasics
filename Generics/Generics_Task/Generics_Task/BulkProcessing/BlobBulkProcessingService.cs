using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItemStorage.StorageProvider;

namespace Generics_Task.BulkProcessing
{
  public class BlobProcessContext
  {
    public string FileName { get; set; }
  }

  public abstract class BlobBulkProcessing<T> where T : BlobProcessContext
  {
    protected readonly IStorageProvider _storageProvider;

    protected BlobBulkProcessing(IStorageProvider storageProvider)
    {
      _storageProvider = storageProvider;
    }

    public BatchResult BulkProcessing(IEnumerable<T> processObjects)
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

    protected abstract void ProcessFile(T processObject);
  }
}
