using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.TemplatePattern.Classic;
namespace MarvellousWorks.PracticalPattern.TemplatePattern.Test.Classic
{
    [TestClass]
    public class TestTemplate
    {
        [TestMethod]
        public void Test()
        {
            IAbstract i1 = new ArrayData();
            Assert.IsTrue(Math.Abs(i1.Average - 2.2) <= 0.001);
            IAbstract i2 = new ListData();
            Assert.IsTrue(Math.Abs(i1.Average - i2.Average) <= 0.001);
        }
    }
}
