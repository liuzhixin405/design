using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.BuilderPattern.Sync;
namespace MarvellousWorks.PracticalPattern.BuilderPattern.Test.Sync
{
    [TestClass]
    public class TestBuilder
    {
        [TestMethod]
        public void Test()
        {
            IBuilder builder = new ConcreteBuilder();
            Car car = builder.BuildUp();
            Assert.IsNotNull(car);
        }
    }
}
