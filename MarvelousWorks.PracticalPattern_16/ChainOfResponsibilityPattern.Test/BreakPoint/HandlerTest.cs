using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.ChainOfResponsibilityPattern.BreakPoint;
namespace ChainOfResponsibilityPattern.Test.BreakPoint
{
    [TestClass]
    public class HandlerTest
    {
        private PurchaseType currentType;

        [TestMethod]
        public void Test()
        {
            // ���ɲ�������ʵ������װ��ʽ�ṹ
            IHandler handler1 = new InternalHandler();
            IHandler handler2 = new DiscountHandler();
            IHandler handler3 = new MailHandler();
            IHandler handler4 = new RegularHandler();
            handler1.Successor = handler3;
            handler3.Successor = handler2;
            handler2.Successor = handler4;
            IHandler head = handler1;

            handler1.HasBreakPoint = true;
            handler1.Break += this.Break;
            handler3.HasBreakPoint = true;
            handler3.Break += this.Break;

            Request request = new Request(20, PurchaseType.Regular);
            head.HandleRequest(request);
            currentType = PurchaseType.Internal;    // Ϊ��һ���ϵ�����׼��
            Assert.AreEqual<double>(20, request.Price);
        }

        void Break(object sender, CallHandlerEventArgs args)
        {
            IHandler handler = args.Handler;
            Assert.AreEqual<PurchaseType>(currentType, args.Handler.Type);
            currentType = PurchaseType.Mail;    // Ϊ�ڶ����������޸�
            args.Handler.HasBreakPoint = false;
            args.Handler.HandleRequest(args.Request);
            
        }
    }
}
