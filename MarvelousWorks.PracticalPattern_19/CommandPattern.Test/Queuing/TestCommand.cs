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
            /// 客户程序只需要按照自己的进度提交命令即可
            CommandQueue queue = new CommandQueue();
            queue.Enqueue(new Receiver1().A);
            queue.Enqueue(new Receiver2().B);
            queue.Enqueue(Receiver3.C);

            /// 实际处理的对象也按照自己的进度执行命令对象
            Invoker invoker = new Invoker(queue);
            invoker.Run();
        }
    }
}
