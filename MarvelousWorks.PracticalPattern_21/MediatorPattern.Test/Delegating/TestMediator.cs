using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.MediatorPattern.Delegating;
namespace MarvellousWorks.PracticalPattern.MediatorPattern.Test.Delegating
{
    [TestClass]
    public class TestMediator
    {
        public class A : ColleagueBase<int>
        {
            public event EventHandler<DataEventArgs<int>> Changed;
            public override int Data
            {
                get{return base.Data;}
                set
                {
                    base.Data = value;
                    /// ����Ϣ�׸���Ϊ�н��.NET�¼�����
                    Changed(this, new DataEventArgs<int>(value));
                }
            }
        }
        public class B : ColleagueBase<int> { }
        public class C : ColleagueBase<int> { }

        [TestMethod]
        public void Test()
        {
            // ��֤.NET�¼���Э��������֪ͨ����
            // ����.NET�¼�������Ϊ������Mediator�������
            A a = new A();
            B b = new B();
            C c = new C();
            a.Changed += b.OnChanged;
            a.Changed += c.OnChanged;
            a.Data = 20;
            Assert.AreEqual<int>(20, b.Data);
            Assert.AreEqual<int>(20, c.Data);

            // ����Э����ϵ
            a.Changed -= c.OnChanged;
            a.Data = 30;
            Assert.AreEqual<int>(30, b.Data);
            // C ��Ϊ�����µ�Э����ϵ֮�ڣ����Բ��仯
            Assert.AreEqual<int>(20, c.Data);

        }
    }
}
