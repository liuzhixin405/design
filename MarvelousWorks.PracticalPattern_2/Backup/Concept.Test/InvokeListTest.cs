using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.Concept.Delegating;
namespace MarvellousWorks.PracticalPattern.Concept.Test
{
    [TestClass()]
    public class InvokeListTest
    {
        [TestMethod()]
        public void Test()
        {
            string message = string.Empty;
            InvokeList list = new InvokeList();
            //list.Invoke();
            Assert.AreEqual<string>("hello,world", list[0] + list[1] + list[2]);
        }
    }
}
