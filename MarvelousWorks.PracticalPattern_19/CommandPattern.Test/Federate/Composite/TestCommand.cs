using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.CommandPattern.Federate.Composite;
namespace MarvellousWorks.PracticalPattern.CommandPattern.Test.Federate.Composite
{
    [TestClass]
    public class TestCommand
    {
        /// <summary>
        /// 记录中间操作过程
        /// </summary>
        static IList<string> Log = new List<string>();

        class CommandA : CommandLeaf
        {
            public override void Execute() { TestCommand.Log.Add("A"); }
        }

        class CommandB : CommandLeaf
        {
            public override void Execute() { TestCommand.Log.Add("B"); }
        }


        [TestMethod]
        public void Test()
        {
            ICommand command = new CommandCompsite();
            command.Add(new CommandA());
            command.Add(new CommandB());
            ICommand subCommand = new CommandCompsite();
            subCommand.Add(new CommandB());
            command.Add(subCommand);
            command.Execute();

            // 确认实际只有三个叶子节电的ICommand被执行了
            Assert.AreEqual<int>(3, Log.Count);
            /// 确认执行次序
            Assert.AreEqual<string>("A", Log[0]);
            Assert.AreEqual<string>("B", Log[1]);
            Assert.AreEqual<string>("B", Log[2]);
        }
    }
}
