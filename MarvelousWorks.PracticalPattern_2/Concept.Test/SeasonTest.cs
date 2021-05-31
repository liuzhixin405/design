using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.Concept.Operator;
namespace MarvellousWorks.PracticalPattern.Concept.Test
{
    [TestClass()]
    public class SeasonTest
    {
        [TestMethod]
        public void Test()
        {
            Season season = new Season();
            Assert.AreEqual<string>(Season.Seasons[0], season);
            season++;
            season++;
            Assert.AreEqual<string>(Season.Seasons[2], season);
        }
    }
}
