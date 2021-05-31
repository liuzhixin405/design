using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.Concept.Delegating;
namespace MarvellousWorks.PracticalPattern.Concept.Test
{
    [TestClass()]
    public class MulticastDelegateInvokerTest
    {
        [TestMethod()]
        public void Test()
        {
            MulticastDelegateInvoker invoker = new MulticastDelegateInvoker();
            Assert.AreEqual<string>("hello,world", invoker[0] + invoker[1] + invoker[2]);
        }
    }
}
