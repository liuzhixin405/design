using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.IteratorPattern.Classic;
namespace MarvellousWorks.PracticalPattern.IteratorPattern.Test.Classic
{
    [TestClass]
    public class TestIterator
    {
        [TestMethod]
        public void Test()
        {
            IAggregate target = new Aggregate();
            target.Add("A");
            target.Add("B");
            IIterator iterator = target.CreaetIterator();
            Assert.AreEqual<string>("A", iterator.Next());
            Assert.AreEqual<string>("B", iterator.Next());
            try
            {
                iterator.Next();
            }
            catch (Exception exception)
            {
                Assert.IsTrue(exception is IndexOutOfRangeException);
            }
        }
    }
}
