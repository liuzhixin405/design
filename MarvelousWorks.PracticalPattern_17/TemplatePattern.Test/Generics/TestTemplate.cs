using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.TemplatePattern.Generics;
namespace MarvellousWorks.PracticalPattern.TemplatePattern.Test.Generics
{
    [TestClass]
    public class TestTemplate
    {
        /// <summary>
        /// 客户程序在使用时，通过指定具体的参数类型，在保证算法
        /// 结构稳定的情况下（即满足模版要求），根据客户程序的执行
        /// 需要具体化算法
        /// </summary>
        [TestMethod]
        public void Test()
        {
            TemplateList<int> list = new TemplateList<int>();
            list.Add(2);
            list.Add(3);
            int i = 3;
            foreach (int data in list)
                Assert.AreEqual<int>(i--, data);
        }
    }
}
