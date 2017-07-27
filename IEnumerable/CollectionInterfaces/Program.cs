using CollectionInterfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;


public class Demo
{
  public static void Main()
  {
    Dinosaurs dinosaurs = new Dinosaurs();

    dinosaurs.Changed += ChangedHandler;

    dinosaurs.Add("Psitticosaurus");
    dinosaurs.Add("Caudipteryx");
    dinosaurs.Add("Compsognathus");
    dinosaurs.Add("Muttaburrasaurus");

    Display(dinosaurs);

    Console.WriteLine("\nIndexOf(\"Muttaburrasaurus\"): {0}",
        dinosaurs.IndexOf("Muttaburrasaurus"));

    Console.WriteLine("\nContains(\"Caudipteryx\"): {0}",
        dinosaurs.Contains("Caudipteryx"));

    Console.WriteLine("\nInsert(2, \"Nanotyrannus\")");
    dinosaurs.Insert(2, "Nanotyrannus");

    Console.WriteLine("\ndinosaurs[2]: {0}", dinosaurs[2]);

    Console.WriteLine("\ndinosaurs[2] = \"Microraptor\"");
    dinosaurs[2] = "Microraptor";

    Console.WriteLine("\nRemove(\"Microraptor\")");
    dinosaurs.Remove("Microraptor");

    Console.WriteLine("\nRemoveAt(0)");
    dinosaurs.RemoveAt(0);

    Display(dinosaurs);
  }

  private static void Display(Collection<string> cs)
  {
    Console.WriteLine();
    foreach (string item in cs)
    {
      Console.WriteLine(item);
    }
  }

  private static void ChangedHandler(object source,
      DinosaursChangedEventArgs e)
  {

    if (e.ChangeType == ChangeType.Replaced)
    {
      Console.WriteLine("{0} was replaced with {1}", e.ChangedItem,
          e.ReplacedWith);
    }
    else if (e.ChangeType == ChangeType.Cleared)
    {
      Console.WriteLine("The dinosaur list was cleared.");
    }
    else
    {
      Console.WriteLine("{0} was {1}.", e.ChangedItem, e.ChangeType);
    }
  }
}

/* This code example produces the following output:

Psitticosaurus was Added.
Caudipteryx was Added.
Compsognathus was Added.
Muttaburrasaurus was Added.

Psitticosaurus
Caudipteryx
Compsognathus
Muttaburrasaurus

IndexOf("Muttaburrasaurus"): 3

Contains("Caudipteryx"): True

Insert(2, "Nanotyrannus")
Nanotyrannus was Added.

dinosaurs[2]: Nanotyrannus

dinosaurs[2] = "Microraptor"
Nanotyrannus was replaced with Microraptor

Remove("Microraptor")
Microraptor was Removed.

RemoveAt(0)
Psitticosaurus was Removed.

Caudipteryx
Compsognathus
Muttaburrasaurus
 */
