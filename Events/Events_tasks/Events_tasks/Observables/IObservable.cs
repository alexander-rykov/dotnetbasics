using Events_tasks.Observers;

namespace Events_tasks.Observables
{
  public interface IObservable
  {
    void RegisterObserver(IObserver o);
    void RemoveObserver(IObserver o);
    void NotifyObservers();
  }
}