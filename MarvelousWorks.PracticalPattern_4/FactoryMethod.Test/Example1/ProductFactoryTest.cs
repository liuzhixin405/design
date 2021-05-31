using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MarvellousWorks.PracticalPattern.FactoryMethod.Example1;
namespace FactoryMethod.Test.Example1
{
    [TestClass()]
    public class ProductFactoryTest
    {
        /// <summary>
        /// 说明静态工厂可以根据提供的目标类型枚举变量选择需要实例化的类型。
        /// </summary>
        [TestMethod]
        public void Test()
        {
            IProduct product = ProductFactory.Create(Category.B);
            Assert.IsNotNull(product);
            Assert.AreEqual<Type>(typeof(ConcreteProductB), product.GetType());
        }
    }
}
