using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics_Task
{
  public class BatchResult
  {
    public bool Success
    {
      get { return !Errors.Any(); }
    }

    public void AddErrors(IEnumerable<string> errors)
    {
      if (errors == null)
      {
        throw new ArgumentNullException("errors");
      }

      if (errors.Any())
      {
        _errors.AddRange(errors);
      }
    }

    public void AddError(Exception ex)
    {
      AddErrors(new[] { ex.ToString() });
    }

    public void AddError(string error)
    {
      AddErrors(new[] { error });
    }

    private readonly List<string> _errors = new List<string>();

    public int ErrorCount
    {
      get { return _errors.Count; }
    }

    public IEnumerable<string> Errors
    {
      get { return _errors; }
    }
  }
}
