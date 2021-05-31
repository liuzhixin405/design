using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.CommandPattern.Classic
{
    /// <summary>
    /// 抽象命令对象
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// 提供给调用者的统一操作方法
        /// </summary>
        void Execute();
        /// <summary>
        /// 定义命令对象实际操作的对象
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
    /// 具体命令对象
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
