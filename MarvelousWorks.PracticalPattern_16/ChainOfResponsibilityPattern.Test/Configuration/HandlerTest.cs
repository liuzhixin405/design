using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.ChainOfResponsibilityPattern.Configuration;
namespace ChainOfResponsibilityPattern.Test.Configuration
{
    [TestClass]
    public class HandlerTest
    {
        [TestMethod]
        public void Test()
        {
            Runtime runtime = new Runtime();
            IHandler head = runtime.Head;
            Request request = new Request(20, PurchaseType.Discount);
            head.HandleRequest(request);
            Assert.AreEqual<double>(0.9 * 20, request.Price);
        }
    }
}
