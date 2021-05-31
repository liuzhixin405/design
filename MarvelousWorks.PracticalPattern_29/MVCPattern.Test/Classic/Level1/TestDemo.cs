using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.MVCPattern.Classic.Level1;
namespace MarvellousWorks.PracticalPattern.MVCPattern.Test.Classic.Level1
{
    [TestClass]
    public class TestDemo
    {
        [TestMethod]
        public void Test()
        {
            Demo demo = new Demo();
            demo.PrintData();
        }
    }
}
