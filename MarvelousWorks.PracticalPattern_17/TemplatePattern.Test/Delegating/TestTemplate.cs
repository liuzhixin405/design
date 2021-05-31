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
            // 客户程序对算法框架的响应
            counter.Changed += delegate(object sender, CounterEventArgs args)
            {
                Assert.AreEqual<int>(1, args.Value);
            };
            // 触发并验证具体操作算法的结果
            counter.Add();
        }
    }
}
