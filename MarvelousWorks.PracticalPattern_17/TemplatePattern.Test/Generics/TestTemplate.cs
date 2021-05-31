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
        /// �ͻ�������ʹ��ʱ��ͨ��ָ������Ĳ������ͣ��ڱ�֤�㷨
        /// �ṹ�ȶ�������£�������ģ��Ҫ�󣩣����ݿͻ������ִ��
        /// ��Ҫ���廯�㷨
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
