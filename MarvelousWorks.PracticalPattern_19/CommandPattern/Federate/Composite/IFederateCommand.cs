using System;
using System.Collections.Generic;
using MarvellousWorks.PracticalPattern.CommandPattern.Federate;
namespace MarvellousWorks.PracticalPattern.CommandPattern.Federate.Composite
{
    /// <summary>
    /// ͨ�����ģʽʵ�ֵĸ���Commandģʽ
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// ��׼Commandģʽ�ķ���
        /// </summary>
        void Execute();
        /// <summary>
        /// ����������ģʽ�ķ���
        /// </summary>
        /// <param name="command"></param>
        void Add(ICommand command);
    }

    public class CommandCompsite : ICommand
    {
        protected IList<ICommand> children = new List<ICommand>();
        public virtual void Add(ICommand command) { children.Add(command); }
        /// <summary>
        /// ����Ϸ�ʽ���ε���ÿһ������
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
