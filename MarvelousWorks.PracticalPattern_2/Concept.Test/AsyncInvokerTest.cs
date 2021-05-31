using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.Concept.Delegating;
namespace MarvellousWorks.PracticalPattern.Concept.Test
{
    [TestClass()]
    public class AsyncInvokerTest
    {
        [TestMethod()]
        public void Test()
        {
            AsyncInvoker asyncInvoker = new AsyncInvoker();
            System.Threading.Thread.Sleep(3000);
            Assert.AreEqual<string>("method", asyncInvoker.Output[0]);
            Assert.AreEqual<string>("fast", asyncInvoker.Output[1]);
            Assert.AreEqual<string>("slow", asyncInvoker.Output[2]);
        }
    }
}
