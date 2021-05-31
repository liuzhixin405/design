using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.BuilderPattern.Configurable;
namespace MarvellousWorks.PracticalPattern.BuilderPattern.Test.Configurable
{
    [TestClass]
    public class TestBuilder
    {
        [TestMethod]
        public void Test()
        {
            IBuilder builder = new ConcreteBuilder();
            IProduct product = builder.Create("car");
            Assert.IsNotNull(product);
            Assert.AreEqual<double>(50000, product.Price);
            Assert.AreEqual<string>("4", product.Features[0].Description);
        }
    }
}
