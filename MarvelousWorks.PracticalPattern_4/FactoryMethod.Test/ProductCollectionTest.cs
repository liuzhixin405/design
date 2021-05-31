using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.FactoryMethod;
namespace FactoryMethod.Test
{
    [TestClass()]
    public class ProductCollectionTest
    {
        [TestMethod]
        public void Test()
        {
            ProductCollection collection = new ProductCollection();
            for (int i = 0; i < 3; i++) collection.Insert(new ProductA());
            Assert.AreEqual<int>(3, collection.Count);
            IProduct[] products = collection.Data;
            foreach (IProduct product in products) Assert.AreEqual<string>("A", product.Name);
        }
    }
}
