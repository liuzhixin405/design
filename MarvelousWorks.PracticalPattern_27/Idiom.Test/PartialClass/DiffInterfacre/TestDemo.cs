using System;
using System.Collections.Generic;
using MarvellousWorks.PracticalPattern.Idiom.PartialClass.DiffInterfacre;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace MarvellousWorks.PracticalPattern.Idiom.Test.PartialClass.DiffInterfacre
{
    [TestClass]
    public class TestDemo
    {
        /// <summary>
        /// �ֲ�ʵ�ֲ���Ӱ��ͻ������ʹ��
        /// </summary>
        [TestMethod]
        public void Test()
        {
            IA a = new C();
            a.MethodA();
            IB b = new C();
            b.MethodB();
        }
    }
}
