using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.MediatorPattern.Classic;
namespace MarvellousWorks.PracticalPattern.MediatorPattern.Test.Classic
{
    [TestClass]
    public class TestMediator
    {
        /// <summary>
        /// provider
        /// </summary>
        class A : ColleagueBase<int> 
        {
            public override int Data
            {
                get { return base.Data; }
                set
                {
                    base.Data = value;
                    mediator.Change();
                }
            }
        }
        /// <summary>
        /// consumer
        /// </summary>
        class B : ColleagueBase<int> { }
        class C : ColleagueBase<int> { }

        [TestMethod]
        public void Test()
        {
            // ��֤Mediator��Э��������֪ͨ����
            Mediator<int> mA2BC = new Mediator<int>();
            A a = new A();
            B b = new B();
            C c = new C();
            a.Mediator = mA2BC;
            b.Mediator = mA2BC;
            c.Mediator = mA2BC;
            mA2BC.Introduce(a, b, c);
            a.Data = 20;
            Assert.AreEqual<int>(20, b.Data);
            Assert.AreEqual<int>(20, c.Data);

            // ����Э����ϵ
            Mediator<int> mA2B = new Mediator<int>();
            a.Mediator = mA2B;
            b.Mediator = mA2B;
            c.Mediator = mA2B;
            mA2B.Introduce(a, b);
            a.Data = 30;
            Assert.AreEqual<int>(30, b.Data);
            // C ��Ϊ�����µ�Э����ϵ֮�ڣ����Բ��仯
            Assert.AreEqual<int>(20, c.Data);
        }
    }
}
