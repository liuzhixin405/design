using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.ObserverPattern.Concept1;
namespace MarvellousWorks.PracticalPattern.ObserverPattern.Test.Concept1
{
    [TestClass]
    public class TestDemo
    {
        [TestMethod]
        public void Test()
        {
            A a = new A();
            B b = new B();
            C c = new C();

            X x = new X();
            x.instanceA = a;
            x.instanceB = b;
            x.instanceC = c;
            x.SetData(10);

            Assert.AreEqual<int>(10, a.Data);
            Assert.AreEqual<int>(10, b.Count);
            Assert.AreEqual<int>(10, c.N);
        }
    }
}
