using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.CommandPattern.Classic;
namespace MarvellousWorks.PracticalPattern.CommandPattern.Test.Classic
{
    [TestClass]
    public class TestCommand
    {
        [TestMethod]
        public void Test()
        {
            // ����Receiver����
            Receiver receiver = new Receiver();

            // ��֯Command����
            ICommand command1 = new SetNameCommand();
            ICommand command2 = new SetAddressCommand();
            command1.Receiver = receiver;
            command2.Receiver = receiver;

            // ��������ߣ�����Command����
            Invoker invoker = new Invoker();
            invoker.AddCommand(command1);
            invoker.AddCommand(command2);

            Assert.AreEqual<string>(string.Empty, receiver.Name);
            Assert.AreEqual<string>(string.Empty, receiver.Address);

            // ʵ��ִ�е��ò�������ú��Ч��
            invoker.Run();
            Assert.AreEqual<string>("name", receiver.Name);
            Assert.AreEqual<string>("address", receiver.Address);
        }
    }
}
