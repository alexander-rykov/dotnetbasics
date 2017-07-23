using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections;

namespace CollectionSamples
{
    [TestClass]
    public class CollectionSample
    {
        public class A : IEnumerable<int>
        {
            // For collection-like init
            public void Add(string s) { } 
            public void Add(int s) { }  

            // For dictionary-like init
            public void Add(int a, string b) { }

            public IEnumerator<int> GetEnumerator()
            {
                throw new NotImplementedException();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }

        [TestMethod]
        public void InitCollections()
        {
            var c1 = new List<int> { 1, 2, 3 };
            var c2 = new Collection<int> { 4, 5, 6 };
            // Do not work
            //var s1 = new Stack<int>() { 7, 8, 9 };

            var c3 = new ReadOnlyCollection<int>(new List<int> { 1, 2, 3 });

            var d1 = new Dictionary<int, int> { { 1, 11 }, { 2, 22 } };
            var d2 = new ReadOnlyDictionary<int, int>(new Dictionary<int, int> { { 1, 11 }, { 2, 22 } });

            var t = new A { "", 35 };

            var t1 = new A { { 1, "" }, { 2, "" } };
        }
    }
}
