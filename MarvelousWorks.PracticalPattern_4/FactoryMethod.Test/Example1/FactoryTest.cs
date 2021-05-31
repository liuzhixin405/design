using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.FactoryMethod.Example1;
namespace FactoryMethod.Test.Example1
{
    [TestClass()]
    public class FactoryTest
    {
        /// <summary>
        /// 说明可以按照要求生成抽象类型，但具体实例化哪个类型由工厂决定。
        /// </summary>
        [TestMethod]
        public void Test()
        {
            Factory factory = new Factory();
            IProduct product = factory.Create();    
            Assert.AreEqual<Type>(product.GetType(), typeof(ConcreteProductA)); 
        }
    }
}
