using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CollectionSamples
{
    [TestClass]
    public class ImutableEnumerators
    {
        [TestMethod]
        //[ExpectedException(typeof(InvalidOperationException))]
        public void ListRemove1()
        {
            var list = new List<int> { 1, 4, 8, 2, 5, 7, 4 };

            var e = list.GetEnumerator();
            while (e.MoveNext())    // System.InvalidOperationException
                                    // Collection was modified; 
                                    //      enumeration operation may not execute.
            {
                if (e.Current > 5)
                    list.Remove(e.Current);
            }
        }

        [TestMethod]
        public void ListRemove2()
        {
            var list = new List<int> { 1, 4, 8, 2, 5, 7, 4 };
                        
            list.Remove(8);
            list.Remove(7);
        }
    }
}
