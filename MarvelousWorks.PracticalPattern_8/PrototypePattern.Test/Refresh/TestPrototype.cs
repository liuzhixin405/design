using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.PrototypePattern.Refresh;
namespace MarvellousWorks.PracticalPattern.PrototypePattern.Test.Refresh
{
    [TestClass]
    public class TestPrototype
    {
        [TestMethod]
        public void Test()
        {
            ConcretePrototype p1 = new ConcretePrototype();
            p1.Name = "Hello";
            ConcretePrototype p2 = (ConcretePrototype)p1.Clone();
            Assert.AreEqual<string>("Hello", p2.Name);
        }
    }
}
