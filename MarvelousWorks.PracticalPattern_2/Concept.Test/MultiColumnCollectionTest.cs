using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.Concept.Indexer;
using System.Data;
namespace MarvellousWorks.PracticalPattern.Concept.Test
{
    [TestClass()]
    public class MultiColumnCollectionTest
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual("joe", MultiColumnCollection.Data.Tables[0].Rows[0]["name"]);
            Assert.AreEqual("female", MultiColumnCollection.Data.Tables[0].Rows[1][1]);
        }
    }
}
