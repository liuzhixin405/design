using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.Concept.Delegating;
namespace MarvellousWorks.PracticalPattern.Concept.Test
{
    [TestClass()]
    public class OverloadMulticastDelegateInvokerTest
    {
        [TestMethod]
        public void Test()
        {
            int result = 10;
            int expected = result;
            OverloadableDelegateInvoker invoker = new OverloadableDelegateInvoker();
            IDictionary<string, int> data = new Dictionary<string, int>();
            invoker.Memo(1, 2, data);
            Assert.AreEqual<int>(1 + 2, data["A"]);
            Assert.AreEqual<int>(1 - 2, data["S"]);
            Assert.AreEqual<int>(1 * 2, data["M"]);
        }
    }
}
