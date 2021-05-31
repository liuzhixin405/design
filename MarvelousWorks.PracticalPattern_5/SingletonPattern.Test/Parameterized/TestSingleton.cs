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
            // ��֤�Ƿ����
            Assert.AreEqual<string>("Hello world", Singleton.Instance.Message);
        }
    }
}
