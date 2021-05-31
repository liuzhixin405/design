using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using MarvellousWorks.PracticalPattern.Concept.Operator;
namespace MarvellousWorks.PracticalPattern.Concept.Test
{
    [TestClass()]
    public class AdapteeTest
    {
        [TestMethod]
        public void Test()
        {
            Adaptee adaptee = new Adaptee();
            Target target = adaptee;
            Assert.AreEqual<int>(adaptee.Code, target.Data);
            List<Target> targets = new List<Target>();
            targets.Add(adaptee);
            targets.Add(adaptee);
            Assert.AreEqual<int>(adaptee.Code, targets[1].Data);
        }
    }
}
