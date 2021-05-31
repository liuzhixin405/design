using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.Concept.Indexer;
namespace MarvellousWorks.PracticalPattern.Concept.Test
{
    [TestClass()]
    public class FederateIndexerTest
    {
        [TestMethod]
        public void Test()
        {
            FederateIndexer f = new FederateIndexer();
            User user = f["K", 22]; // 按照联合索引定位
            Assert.AreEqual<Gender>(Gender.Female, user.Gender);
        }
    }
}
