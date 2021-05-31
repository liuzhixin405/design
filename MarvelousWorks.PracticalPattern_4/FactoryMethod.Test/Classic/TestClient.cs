using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.FactoryMethod;
using MarvellousWorks.PracticalPattern.FactoryMethod.Classic;
namespace FactoryMethod.Test.Classic
{
    public class Client
    {
        private IFactory factory;
        public Client(IFactory factory)     // 将IFactory通过Setter方式注入
        {
            if (factory == null) throw new ArgumentNullException("factory");
            this.factory = factory;
        }

        public IProduct GetProduct() { return factory.Create(); }
    }

    [TestClass]
    public class TestClient
    {
        [TestMethod]
        public void Test()
        {
            IFactory factory = (new Assembler()).Create<IFactory>();
            Client client = new Client(factory);    // 注入IFactory
            IProduct product = client.GetProduct(); // 通过IFactory获取IProduct
            // 由于配置中选择为FactoryA，所以加工的产品为ProductA
            // <add key="IFactory"   
            // value="MarvellousWorks.PracticalPattern.FactoryMethod.Classic.FactoryA,
            // MarvellousWorks.PracticalPattern.FactoryMethod"/>
            Assert.AreEqual<string>("A", product.Name); 
        }
    }
}
