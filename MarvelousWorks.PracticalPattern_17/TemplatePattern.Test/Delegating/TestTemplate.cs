using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.TemplatePattern.Delegating;
namespace MarvellousWorks.PracticalPattern.TemplatePattern.Test.Delegating
{
    [TestClass]
    public class TestTemplate
    {
        [TestMethod]
        public void Test()
        {
            Counter counter = new Counter();
            // �ͻ�������㷨��ܵ���Ӧ
            counter.Changed += delegate(object sender, CounterEventArgs args)
            {
                Assert.AreEqual<int>(1, args.Value);
            };
            // ��������֤��������㷨�Ľ��
            counter.Add();
        }
    }
}
