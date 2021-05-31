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
            // 建立对象，并对其进行两次装饰
            IText text = new TextObject();
            text = new BoldDecorator(text);
            text = new ColorDecorator(text);
            Assert.AreEqual<string>("<color><b>hello</b></color>", text.Content);

            // 建立对象，只对其进行1次装饰
            text = new TextObject();
            text = new ColorDecorator(text);
            Assert.AreEqual<string>("<color>hello</color>", text.Content);

            // 通过装饰，撤销某些操作
            text = new BlockAllDecorator(text);
            Assert.IsTrue(string.IsNullOrEmpty(text.Content));
        }
    }
}
