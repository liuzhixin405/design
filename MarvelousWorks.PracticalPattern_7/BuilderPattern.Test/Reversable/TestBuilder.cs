using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.BuilderPattern.Reversable;
namespace MarvellousWorks.PracticalPattern.BuilderPattern.Test.Reversable
{
    [TestClass]
    public class TestBuilder
    {
        [TestMethod]
        public void Test()
        {
            IBuilder<Product> builder = new ProductBuilder();
            Product product = builder.BuildUp();
            Assert.AreEqual<int>(5, product.Count);
            Assert.AreEqual<int>(5, product.Items.Count);
            product = builder.TearDown();
            Assert.AreEqual<int>(0, product.Count);
            Assert.AreEqual<int>(0, product.Items.Count);
        }
    }
}
