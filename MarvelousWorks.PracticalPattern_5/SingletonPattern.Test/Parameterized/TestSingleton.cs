using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.SingletonPattern.Parameterized;
namespace SingletonPattern.Test.Parameterized
{
    [TestClass]
    public class TestSingleton
    {
        [TestMethod]
        public void Test()
        {
            // 验证是否可以
            Assert.AreEqual<string>("Hello world", Singleton.Instance.Message);
        }
    }
}
