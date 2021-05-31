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
        /// ��¼�м��������
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

            // ȷ��ʵ��ֻ������Ҷ�ӽڵ��ICommand��ִ����
            Assert.AreEqual<int>(3, Log.Count);
            /// ȷ��ִ�д���
            Assert.AreEqual<string>("A", Log[0]);
            Assert.AreEqual<string>("B", Log[1]);
            Assert.AreEqual<string>("B", Log[2]);
        }
    }
}
