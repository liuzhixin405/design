using System;
using System.Collections.Generic;
using MarvellousWorks.PracticalPattern.CommandPattern.Federate;
namespace MarvellousWorks.PracticalPattern.CommandPattern.Federate.Composite
{
    /// <summary>
    /// 通过组合模式实现的复合Command模式
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// 标准Command模式的方法
        /// </summary>
        void Execute();
        /// <summary>
        /// 用于完成组合模式的方法
        /// </summary>
        /// <param name="command"></param>
        void Add(ICommand command);
    }

    public class CommandCompsite : ICommand
    {
        protected IList<ICommand> children = new List<ICommand>();
        public virtual void Add(ICommand command) { children.Add(command); }
        /// <summary>
        /// 以组合方式依次调用每一个方法
        /// </summary>
        public virtual void Execute()
        {
            foreach (ICommand command in children)
                command.Execute();
        }
    }

    public abstract class CommandLeaf : ICommand
    {
        public void Add(ICommand command)
        {
            throw new NotSupportedException("Leaf command object");
        }

        public abstract void Execute();
    }
}
