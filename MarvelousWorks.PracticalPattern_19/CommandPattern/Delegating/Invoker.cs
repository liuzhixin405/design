using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.CommandPattern.Delegating
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
    /// 调用者
    /// </summary>
    public class Invoker
    {
        IList<VoidHandler> handlers = new List<VoidHandler>();
        public void AddHandler(VoidHandler handler) { handlers.Add(handler); }

        public void Run()
        {
            foreach (VoidHandler handler in handlers)
                handler();
        }
    }
}
