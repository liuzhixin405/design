using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.Concept.Indexer;
namespace MarvellousWorks.PracticalPattern.Concept.Test
{
    [TestClass()]
    public class SimpleColumnCollectionTest
    {
        [TestMethod]
        public void Test()
        {
            SingleColumnCollection c = new SingleColumnCollection();
            Assert.AreEqual<string>("china", c[0]);
            Assert.AreEqual<int>(2, c["ch"].Length); // 命中china和chile两项
            Assert.AreEqual<string>("china", c["ch"][0]);
        }
    }
}
