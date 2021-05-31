using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.Concept.Delegating;
namespace MarvellousWorks.PracticalPattern.Concept.Test
{
    [TestClass()]
    public class UglySmartDelegateInvokerTest
    {
        [TestMethod()]
        public void Test()
        {
            UglySmartDelegateInvoker target = new UglySmartDelegateInvoker();
            Assert.AreEqual<int>(2 + 3, (int)target.Invoke(2, 3));
        }
    }
}
