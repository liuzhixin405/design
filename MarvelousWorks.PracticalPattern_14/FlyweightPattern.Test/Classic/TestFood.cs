using System;
using System.Collections.Generic;
using MarvellousWorks.PracticalPattern.FlyweightPattern.Classic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace FlyweightPattern.Test.Classic
{
    [TestClass]
    public class TestFood
    {
        [TestMethod]
        public void Test() 
        {
            FoodFactory factory = new FoodFactory();
            FoodBase f1 = factory.Create("Cheese");
            FoodBase f2 = factory.Create("Cheese");
            Assert.IsNotNull(f1);
            Assert.AreEqual<int>(f1.GetHashCode(), f2.GetHashCode());
            FoodBase f3 = factory.Create("Capsicum");
            Assert.AreNotEqual<int>(f1.GetHashCode(), f3.GetHashCode());
        }
    }
}
