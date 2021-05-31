using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MarvellousWorks.PracticalPattern.Common;
namespace MarvellousWorks.PracticalPattern.Common.Test
{
    [TestClass()]
    public class GenericCacheTest
    {
        [TestMethod()]
        public void AddTest()
        {
            GenericCache<int, int> cache = new GenericCache<int, int>();
            cache.Add(1, 1001);
            cache.Add(2, 1002);
            Assert.AreEqual<int>(2, cache.Count);
        }

        [TestMethod()]
        public void ClearTest()
        {
            GenericCache<int, int> cache = new GenericCache<int, int>();
            cache.Add(1, 1001);
            cache.Add(2, 1002);
            Assert.AreEqual<int>(2, cache.Count);
            cache.Clear();
            Assert.AreEqual<int>(0, cache.Count);
        }

        [TestMethod()]
        public void ContainsKeyTest()
        {
            GenericCache<int, int> cache = new GenericCache<int, int>();
            cache.Add(1, 1001);
            cache.Add(2, 1002);
            Assert.IsTrue(cache.ContainsKey(1));
            Assert.IsFalse(cache.ContainsKey(3));
        }

        [TestMethod()]
        public void TryGetValueTest()
        {
            GenericCache<int, int> cache = new GenericCache<int, int>();
            cache.Add(1, 1001);
            cache.Add(2, 1002);
            int result;
            Assert.IsTrue(cache.TryGetValue(1, out result));
            Assert.AreEqual<int>(1001, result);
            Assert.IsFalse(cache.TryGetValue(3, out result));
        }
    }
}
