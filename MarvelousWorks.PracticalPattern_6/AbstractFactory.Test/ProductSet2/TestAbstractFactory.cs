using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.AbstractFactory.ProductSet2;
namespace AbstractFactory.Test.ProductSet2
{
    [TestClass]
    public class TestAbstractFactory
    {
        IAbstractFactory AssemblyFactory()
        {
            // ����ӳ���ϵ�ֵ䣬�����ֵ�ע�뵽IAbstractFactory��
            // ʵ����Ŀ�������������ͨ����ȡ�����ļ���ɵ�
            IDictionary<Type, Type> mapper = new Dictionary<Type, Type>();
            mapper.Add(typeof(IProductA), typeof(ProductA1));
            mapper.Add(typeof(IProductB), typeof(ProductB1));
            return new ConcreteFactory(mapper); // ע��
        }

        [TestMethod]
        public void Test()
        {
            IAbstractFactory factory = AssemblyFactory();
            IProductA productA = factory.Create<IProductA>();
            IProductB productB = factory.Create<IProductB>();
            Assert.AreEqual<Type>(typeof(ProductA1), productA.GetType());
            Assert.AreEqual<Type>(typeof(ProductB1), productB.GetType());
        }
    }
}
