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
            // 生成映射关系字典，并将字典注入到IAbstractFactory中
            // 实际项目中这个过程往往通过读取配置文件完成的
            IDictionary<Type, Type> mapper = new Dictionary<Type, Type>();
            mapper.Add(typeof(IProductA), typeof(ProductA1));
            mapper.Add(typeof(IProductB), typeof(ProductB1));
            return new ConcreteFactory(mapper); // 注入
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
