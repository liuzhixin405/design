using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.IteratorPattern.Pure;
namespace MarvellousWorks.PracticalPattern.IteratorPattern.Test.Pure
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
            int i = 0;
            foreach (string message in target) 
                i++;
            Assert.AreEqual<int>(2, i);
        }
    }
}
