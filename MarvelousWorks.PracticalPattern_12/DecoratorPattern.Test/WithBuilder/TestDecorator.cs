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
            // �޸ĺ��IText����������һ��Builder����
            IText text = new TextObject();
            text = (new DecoratorBuilder()).BuildUp(text);
            Assert.AreEqual<string>("<color><b>hello</b></color>", text.Content);
        }
    }
}
