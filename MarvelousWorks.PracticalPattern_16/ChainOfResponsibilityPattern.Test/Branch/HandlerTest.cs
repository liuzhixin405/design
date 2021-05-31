using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.ChainOfResponsibilityPattern.Branch;
namespace ChainOfResponsibilityPattern.Test.Branch
{
    [TestClass]
    public class HandlerTest
    {
        [TestMethod]
        public void Test()
        {
            // ���ɲ�������ʵ��
            IHandler handler1 = new InternalHandler();
            IHandler handler2 = new DiscountHandler();
            IHandler handler3 = new MailHandler();
            IHandler handler4 = new RegularHandler();

            //// ��װ��ʽ�Ľṹ  internal-> mail-> discount-> regular-> null
            handler1.AddSuccessor(handler2);
            handler2.AddSuccessor(handler3);
            handler2.AddSuccessor(handler4);
            IHandler head = handler1;

            Request request = new Request(20, PurchaseType.Mail);
            head.HandleRequest(request);
            Assert.AreEqual<double>(20 * 1.3, request.Price);
        }
    }
}
