using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.DecoratorPattern.Classic;
namespace MarvellousWorks.PracticalPattern.DecoratorPattern.Test.Classic
{
    [TestClass]
    public class TestDecorator
    {
        [TestMethod]
        public void Test()
        {
            // �������󣬲������������װ��
            IText text = new TextObject();
            text = new BoldDecorator(text);
            text = new ColorDecorator(text);
            Assert.AreEqual<string>("<color><b>hello</b></color>", text.Content);

            // ��������ֻ�������1��װ��
            text = new TextObject();
            text = new ColorDecorator(text);
            Assert.AreEqual<string>("<color>hello</color>", text.Content);

            // ͨ��װ�Σ�����ĳЩ����
            text = new BlockAllDecorator(text);
            Assert.IsTrue(string.IsNullOrEmpty(text.Content));
        }
    }
}
