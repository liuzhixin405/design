using System;
using System.Collections.Generic;
using System.Text;

namespace MarvellousWorks.PracticalPattern.CommandPattern.Queuing
{
    /// <summary>
    /// 所有操作的委托定义
    /// </summary>
    public delegate void VoidHandler();

    /// <summary>
    /// 不同的接收者类型
    /// </summary>
    public class Receiver1 { public void A() { } }
    public class Receiver2 { public void B() { } }
    public class Receiver3 { public static void C() { } }

    /// <summary>
    /// 保存Command的队列
    /// </summary>
    public class CommandQueue : Queue<VoidHandler>
    {
    }

    /// <summary>
    /// 调用者
    /// </summary>
    public class Invoker
    {
        private CommandQueue queue;

        public Invoker(CommandQueue queue)
        {
            this.queue = queue;
        }

        /// <summary>
        /// 按照队列方式执行排队的命令。相对而言，这时候Invoker
        /// 具有执行的主动性，此处可以嵌入很多其他控制逻辑
        /// </summary>
        public void Run()
        {
            while (queue.Count > 0)
            {
                VoidHandler handler = queue.Dequeue();
                handler();
            }
        }
    }
}
