using System;
using System.Collections.Generic;
using System.Text;

namespace MarvellousWorks.PracticalPattern.CommandPattern.Queuing
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
    /// ����Command�Ķ���
    /// </summary>
    public class CommandQueue : Queue<VoidHandler>
    {
    }

    /// <summary>
    /// ������
    /// </summary>
    public class Invoker
    {
        private CommandQueue queue;

        public Invoker(CommandQueue queue)
        {
            this.queue = queue;
        }

        /// <summary>
        /// ���ն��з�ʽִ���Ŷӵ������Զ��ԣ���ʱ��Invoker
        /// ����ִ�е������ԣ��˴�����Ƕ��ܶ����������߼�
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
