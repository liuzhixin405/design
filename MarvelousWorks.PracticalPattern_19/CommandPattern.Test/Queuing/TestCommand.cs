using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.CommandPattern.Queuing;
namespace MarvellousWorks.PracticalPattern.CommandPattern.Test.Queuing
{
    [TestClass]
    public class TestCommand
    {
        [TestMethod]
        public void Test()
        {
            /// �ͻ�����ֻ��Ҫ�����Լ��Ľ����ύ�����
            CommandQueue queue = new CommandQueue();
            queue.Enqueue(new Receiver1().A);
            queue.Enqueue(new Receiver2().B);
            queue.Enqueue(Receiver3.C);

            /// ʵ�ʴ���Ķ���Ҳ�����Լ��Ľ���ִ���������
            Invoker invoker = new Invoker(queue);
            invoker.Run();
        }
    }
}
