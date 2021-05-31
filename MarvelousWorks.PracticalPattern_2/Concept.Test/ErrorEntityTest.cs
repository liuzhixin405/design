using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.Concept.Operator;
namespace MarvellousWorks.PracticalPattern.Concept.Test
{
    [TestClass()]
    public class ErrorEntityTest
    {
        [TestMethod]
        public void Test()
        {
            ErrorEntity entity = new ErrorEntity();
            entity += "hello";
            entity += 1;
            entity += 2;
            Assert.AreEqual<int>(1, entity.Messages.Count);
            Assert.AreEqual<int>(2, entity.Codes.Count);
        }
    }
}
