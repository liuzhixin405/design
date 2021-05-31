using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.Concept.Attributing;
namespace MarvellousWorks.PracticalPattern.Concept.Test
{
    [TestClass()]
    public class DirectorTest
    {
        [TestMethod]
        public void Test()
        {
            IAttributedBuilder builder = new AttributedBuilder();
            Director director = new Director();
            director.BuildUp(builder);
            Assert.AreEqual<string>("a", builder.Log[0]);
            Assert.AreEqual<string>("b", builder.Log[1]);
            Assert.AreEqual<string>("c", builder.Log[2]);
        }
    }
}
