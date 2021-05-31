using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.StatePattern.Raw;
namespace MarvellousWorks.PracticalPattern.StatePattern.Test.Raw
{
    [TestClass]
    public class TestStoplight
    {
        [TestMethod]
        public void Test()
        {
            StopLight stopLight = new StopLight();  // green
            Assert.AreEqual<Color>(Color.Yellow, stopLight.ChangeColor());
            Assert.AreEqual<Color>(Color.Red, stopLight.ChangeColor());
            Assert.AreEqual<Color>(Color.Green, stopLight.ChangeColor());
        }
    }
}
