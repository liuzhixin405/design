using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MarvellousWorks.PracticalPattern.FactoryMethod.Delegating;
namespace FactoryMethod.Test.Delegating
{
    [TestClass]
    public class TestDelegateFactory
    {
        [TestMethod]
        public void Test()
        {
            IFactory<CalculateHandler> factory = new CalculateHandlerFactory();
            CalculateHandler handler = factory.Create();
            Assert.AreEqual<int>(1 + 2 + 3, handler(1, 2, 3));
        }
    }
}
