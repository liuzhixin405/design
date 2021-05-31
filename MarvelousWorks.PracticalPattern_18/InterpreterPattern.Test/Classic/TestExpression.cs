using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.InterpreterPattern.Classic;
namespace MarvellousWorks.PracticalPattern.InterpreterPattern.Test.Classic
{
    [TestClass]
    public class TestExpression
    {
        [TestMethod]
        public void Test()
        {
            Calculator calculator = new Calculator();
            Assert.AreEqual<int>(1 + 3 - 2, calculator.Calculate("1+3-2"));
        }
    }
}
