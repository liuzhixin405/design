using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.FactoryMethod.Batch;
using MarvellousWorks.PracticalPattern.FactoryMethod;
namespace FactoryMethod.Test.Batch
{
    [TestClass()]
    public class BatchProductAFactoryTest
    {
        [TestMethod]
        public void Test()
        {
            IBatchFactory factory = new BatchProductAFactory();
            ProductCollection collection = factory.Create(4);
            Assert.AreEqual<int>(4, collection.Count);
            foreach (IProduct product in collection.Data)
                Assert.AreEqual<string>("A", product.Name);
        }
    }
}
