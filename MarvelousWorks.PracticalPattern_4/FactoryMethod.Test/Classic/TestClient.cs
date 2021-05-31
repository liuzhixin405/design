using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.FactoryMethod;
using MarvellousWorks.PracticalPattern.FactoryMethod.Classic;
namespace FactoryMethod.Test.Classic
{
    public class Client
    {
        private IFactory factory;
        public Client(IFactory factory)     // ��IFactoryͨ��Setter��ʽע��
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
            Client client = new Client(factory);    // ע��IFactory
            IProduct product = client.GetProduct(); // ͨ��IFactory��ȡIProduct
            // ����������ѡ��ΪFactoryA�����Լӹ��Ĳ�ƷΪProductA
            // <add key="IFactory"   
            // value="MarvellousWorks.PracticalPattern.FactoryMethod.Classic.FactoryA,
            // MarvellousWorks.PracticalPattern.FactoryMethod"/>
            Assert.AreEqual<string>("A", product.Name); 
        }
    }
}
