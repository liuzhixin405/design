using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.ChainOfResponsibilityPattern.Classic;
namespace ChainOfResponsibilityPattern.Test.Classic
{
    [TestClass]
    public class HandlerTest
    {
        [TestMethod]
        public void Test()
        {
            // 生成操作对象实例
            IHandler handler1 = new InternalHandler();
            IHandler handler2 = new DiscountHandler();
            IHandler handler3 = new MailHandler();
            IHandler handler4 = new RegularHandler();

            // 组装链式的结构  internal-> mail-> discount-> regular-> null
            handler1.Successor = handler3;
            handler3.Successor = handler2;
            handler2.Successor = handler4;
            IHandler head = handler1;

            Request request = new Request(20, PurchaseType.Mail);
            head.HandleRequest(request);
            Assert.AreEqual<double>(20 * 1.3, request.Price);

            // 重新组织链表结构
            handler1.Successor = handler1.Successor.Successor;  // 短路掉Discount
            request = new Request(20, PurchaseType.Discount);
            head.HandleRequest(new Request(20, PurchaseType.Discount));
            Assert.AreEqual<double>(20, request.Price);    // 确认被短路的部分无法生效
        }
    }
}
