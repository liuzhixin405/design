using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.ObserverPattern.Concept2;
namespace MarvellousWorks.PracticalPattern.ObserverPattern.Test.Concept2
{
    [TestClass]
    public class TestDemo
    {
        [TestMethod]
        public void Test()
        {
            X x = new X();
            IUpdatableObject a = new A();
            IUpdatableObject b = new B();
            IUpdatableObject c = new C();
            x[0] = a;
            x[1] = b;
            x[2] = c;
            x.Update(10);
            Assert.AreEqual<int>(10, a.Data);
            Assert.AreEqual<int>(10, b.Data);
            Assert.AreEqual<int>(10, c.Data);
        }
    }
}
