using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MarvellousWorks.PracticalPattern.Concept.Delegating;
namespace MarvellousWorks.PracticalPattern.Concept.Test
{
    [TestClass()]
    public class SmartDelegateInvokerTest
    {
        delegate int DualAddHandler(int x, int y);

        [TestMethod]
        public void Test()
        {
            SmartDelegateInvoker invoker = new SmartDelegateInvoker();
            Type type = typeof(DualAddHandler);
            Assert.AreEqual<int>(2 + 3, invoker.Invoke(type, 2, 3));
        }
    }
}
