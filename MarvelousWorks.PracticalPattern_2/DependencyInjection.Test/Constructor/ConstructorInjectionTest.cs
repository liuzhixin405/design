using System;
using MarvellousWorks.PracticalPattern.Concept.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace MarvellousWorks.PracticalPattern.Concept.DependencyInjection.Test.Constructor
{
    /// <summary>
    /// �ڹ��캯����ע��
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
            Assert.IsNotNull(timeProvider);     // ȷ�Ͽ���������ó�������ʵ��
            Client client = new Client(timeProvider);   // �ڹ��캯����ע��
        }
    }
}
