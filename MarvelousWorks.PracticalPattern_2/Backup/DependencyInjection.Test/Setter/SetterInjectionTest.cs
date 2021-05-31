using System;
using MarvellousWorks.PracticalPattern.Concept.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace MarvellousWorks.PracticalPattern.Concept.DependencyInjection.Test.Setter
{
    /// <summary>
    /// ͨ��Setterʵ��ע��
    /// </summary>
    class Client
    {
        private ITimeProvider timeProvider;

        public ITimeProvider TimeProvider
        {
            get { return this.timeProvider; }   // getter�����Setter��ʽʵ��ע��û�й�ϵ
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
            Assert.IsNotNull(timeProvider);     // ȷ�Ͽ���������ó�������ʵ��
            Client client = new Client();
            client.TimeProvider = timeProvider; // ͨ��Setterʵ��ע��
        }
    }
}
