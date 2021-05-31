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
            // 构造Receiver对象
            Receiver receiver = new Receiver();

            // 组织Command对象
            ICommand command1 = new SetNameCommand();
            ICommand command2 = new SetAddressCommand();
            command1.Receiver = receiver;
            command2.Receiver = receiver;

            // 定义调用者，管理Command对象
            Invoker invoker = new Invoker();
            invoker.AddCommand(command1);
            invoker.AddCommand(command2);

            Assert.AreEqual<string>(string.Empty, receiver.Name);
            Assert.AreEqual<string>(string.Empty, receiver.Address);

            // 实际执行调用并检验调用后的效果
            invoker.Run();
            Assert.AreEqual<string>("name", receiver.Name);
            Assert.AreEqual<string>("address", receiver.Address);
        }
    }
}
