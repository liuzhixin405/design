using System;
using MarvellousWorks.PracticalPattern.Concept.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace MarvellousWorks.PracticalPattern.Concept.DependencyInjection.Test.Constructor
{
    /// <summary>
    /// 在构造函数中注入
    /// </summary>
    class Client
    {
        private ITimeProvider timeProvider;

        public Client(ITimeProvider timeProvider)
        {
            this.timeProvider = timeProvider;
        }
    }


    [TestClass]
    public class TestClient
    {
        [TestMethod]
        public void Test()
        {
            ITimeProvider timeProvider = (new Assembler()).Create<ITimeProvider>();
            Assert.IsNotNull(timeProvider);     // 确认可以正常获得抽象类型实例
            Client client = new Client(timeProvider);   // 在构造函数中注入
        }
    }
}
