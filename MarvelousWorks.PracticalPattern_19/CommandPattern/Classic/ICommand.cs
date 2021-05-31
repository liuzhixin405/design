using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.CommandPattern.Classic
{
    /// <summary>
    /// �����������
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// �ṩ�������ߵ�ͳһ��������
        /// </summary>
        void Execute();
        /// <summary>
        /// �����������ʵ�ʲ����Ķ���
        /// </summary>
        Receiver Receiver { set;}

    }

    public abstract class CommandBase : ICommand
    {
        protected Receiver receiver;
        public Receiver Receiver { set { receiver = value; } }
        public abstract void Execute();
    }

    /// <summary>
    /// �����������
    /// </summary>
    public class SetNameCommand : CommandBase
    {
        public override void Execute() { receiver.SetName(); }
    }
    public class SetAddressCommand : CommandBase
    {
        public override void Execute() { receiver.SetAddress(); }
    }
}
