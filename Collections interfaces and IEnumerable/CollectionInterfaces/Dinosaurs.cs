using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionInterfaces
{
  public class Dinosaurs : Collection<string>
  {
    public event EventHandler<DinosaursChangedEventArgs> Changed;

    protected override void InsertItem(int index, string newItem)
    {
      base.InsertItem(index, newItem);

      EventHandler<DinosaursChangedEventArgs> temp = Changed;
      if (temp != null)
      {
        temp(this, new DinosaursChangedEventArgs(
            ChangeType.Added, newItem, null));
      }
    }

    protected override void SetItem(int index, string newItem)
    {
      string replaced = Items[index];
      base.SetItem(index, newItem);

      EventHandler<DinosaursChangedEventArgs> temp = Changed;
      if (temp != null)
      {
        temp(this, new DinosaursChangedEventArgs(
            ChangeType.Replaced, replaced, newItem));
      }
    }

    protected override void RemoveItem(int index)
    {
      string removedItem = Items[index];
      base.RemoveItem(index);

      EventHandler<DinosaursChangedEventArgs> temp = Changed;
      if (temp != null)
      {
        temp(this, new DinosaursChangedEventArgs(
            ChangeType.Removed, removedItem, null));
      }
    }

    protected override void ClearItems()
    {
      base.ClearItems();

      EventHandler<DinosaursChangedEventArgs> temp = Changed;
      if (temp != null)
      {
        temp(this, new DinosaursChangedEventArgs(
            ChangeType.Cleared, null, null));
      }
    }
  }

  public class DinosaursChangedEventArgs : EventArgs
  {
    public readonly string ChangedItem;
    public readonly ChangeType ChangeType;
    public readonly string ReplacedWith;

    public DinosaursChangedEventArgs(ChangeType change, string item,
        string replacement)
    {
      ChangeType = change;
      ChangedItem = item;
      ReplacedWith = replacement;
    }
  }

  public enum ChangeType
  {
    Added,
    Removed,
    Replaced,
    Cleared
  };
}
