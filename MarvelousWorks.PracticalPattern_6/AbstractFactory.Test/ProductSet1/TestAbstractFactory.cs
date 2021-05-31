using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.AbstractFactory;
using MarvellousWorks.PracticalPattern.AbstractFactory.ProductSet1;
namespace AbstractFactory.Test.ProductSet1
{
    [TestClass]
    public class TestAbstractFactory
    {
        [TestMethod]
        public void Test()
        {
            IAbstractFactory factory = new ConcreteFactory(typeof(ProductA1), typeof(ProductB1));
            IProductA productA = factory.CreateProducctA();
            IProductB productB = factory.CreateProducctB();
            Assert.AreEqual<Type>(typeof(ProductA1), productA.GetType());
            Assert.AreEqual<Type>(typeof(ProductB1), productB.GetType());
        }
    }
}
