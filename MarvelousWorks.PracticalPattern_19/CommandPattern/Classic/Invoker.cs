using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.CommandPattern.Classic
{
    /// <summary>
    /// 调用者
    /// </summary>
    public class Invoker
    {
        /// <summary>
        /// 管理相关命令对象
        /// </summary>
        private IList<ICommand> commands = new List<ICommand>();
        public void AddCommand(ICommand command) { commands.Add(command); }

        /// <summary>
        /// 经过调用者组织后，供客户程序操作命令对象的方法
        /// </summary>
        public void Run()
        {
            foreach (ICommand command in commands)
                command.Execute();
        }
    }
}
