using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.FactoryMethod.Batch;
using MarvellousWorks.PracticalPattern.FactoryMethod;
namespace FactoryMethod.Test.Batch
{
    class ProductADecision : DecisionBase
    {
        /// <summary>
        /// 定义 ProductA 的生产计划
        /// </summary>
        public ProductADecision() : base(new BatchProductAFactory(), 2) { }
    }
    class ProductBDecision : DecisionBase
    {
        /// <summary>
        /// 定义 ProductB 的生产计划
        /// </summary>
        public ProductBDecision() : base(new BatchProductBFactory(), 3) { }
    }    

    class ProductDirector : DirectorBase
    {
        public ProductDirector()
        {
            base.Insert(new ProductADecision());
            base.Insert(new ProductBDecision());
        }
    }

    class Client
    {
        /// <summary>
        /// 实际项目中，可以通过Assembler从外部把Director注入
        /// </summary>
        private DirectorBase director = new ProductDirector();

        public IProduct[] Produce()
        {
            ProductCollection collection = new ProductCollection();
            foreach (DecisionBase decision in director.Decisions)
                collection += decision.Factory.Create(decision.Quantity);
            return collection.Data;
        }
    }

    [TestClass]
    public class TestBatchFactory
    {
        [TestMethod]
        public void Test()
        {
            Client client = new Client();
            IProduct[] products = client.Produce();
            Assert.AreEqual<int>(2 + 3, products.Length);
            for (int i = 0; i < 2; i++) Assert.AreEqual<string>("A", products[i].Name);
            for (int i = 2; i < 5; i++) Assert.AreEqual<string>("B", products[i].Name);
        }
    }
}
