using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.CommandPattern.Delegating
{
    /// <summary>
    /// ���в�����ί�ж���
    /// </summary>
    public delegate void VoidHandler();

    /// <summary>
    /// ��ͬ�Ľ���������
    /// </summary>
    public class Receiver1 { public void A() { } }
    public class Receiver2 { public void B() { } }
    public class Receiver3 { public static void C() { } }

    /// <summary>
    /// ������
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
