using System;
using MarvellousWorks.PracticalPattern.Concept.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace MarvellousWorks.PracticalPattern.Concept.DependencyInjection.Test.Setter
{
    /// <summary>
    /// 通过Setter实现注入
    /// </summary>
    class Client
    {
        private ITimeProvider timeProvider;

        public ITimeProvider TimeProvider
        {
            get { return this.timeProvider; }   // getter本身和Setter方式实现注入没有关系
            set { this.timeProvider = value; }
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
            Client client = new Client();
            client.TimeProvider = timeProvider; // 通过Setter实现注入
        }
    }
}
