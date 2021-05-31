using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.CommandPattern.Classic
{
    /// <summary>
    /// ������
    /// </summary>
    public class Invoker
    {
        /// <summary>
        /// ��������������
        /// </summary>
        private IList<ICommand> commands = new List<ICommand>();
        public void AddCommand(ICommand command) { commands.Add(command); }

        /// <summary>
        /// ������������֯�󣬹��ͻ���������������ķ���
        /// </summary>
        public void Run()
        {
            foreach (ICommand command in commands)
                command.Execute();
        }
    }
}
