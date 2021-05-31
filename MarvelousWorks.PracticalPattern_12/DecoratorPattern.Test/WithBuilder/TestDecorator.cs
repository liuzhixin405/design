using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.DecoratorPattern.WithBuilder;
namespace MarvellousWorks.PracticalPattern.DecoratorPattern.Test.WithBuilder
{
    [TestClass]
    public class TestDecorator
    {
        [TestMethod]
        public void Test()
        {
            // 修改后的IText仅仅依赖于一个Builder类型
            IText text = new TextObject();
            text = (new DecoratorBuilder()).BuildUp(text);
            Assert.AreEqual<string>("<color><b>hello</b></color>", text.Content);
        }
    }
}
