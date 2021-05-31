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
            // 验证Mediator对协作对象间的通知作用
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

            // 更改协作关系
            Mediator<int> mA2B = new Mediator<int>();
            a.Mediator = mA2B;
            b.Mediator = mA2B;
            c.Mediator = mA2B;
            mA2B.Introduce(a, b);
            a.Data = 30;
            Assert.AreEqual<int>(30, b.Data);
            // C 因为不在新的协作关系之内，所以不变化
            Assert.AreEqual<int>(20, c.Data);
        }
    }
}
