using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.AbstractFactory;
using MarvellousWorks.PracticalPattern.AbstractFactory.Classic;
namespace AbstractFactory.Test.Classic
{
    [TestClass]
    public class TestAbstractFactory
    {
        [TestMethod]
        public void Test()
        {
            IAbstractFactory factory = new ConcreteFactory2();
            IProductA productA = factory.CreateProducctA();
            IProductB productB = factory.CreateProducctB();
            Assert.AreEqual<Type>(typeof(ProductA2Y), productA.GetType());
            Assert.AreEqual<Type>(typeof(ProductB2), productB.GetType());
        }
    }
}
