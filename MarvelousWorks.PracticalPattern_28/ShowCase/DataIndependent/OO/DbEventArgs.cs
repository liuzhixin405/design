using System;
using System.Data.Common;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.ShowCase.DataIndependent.OO
{
    /// <summary>
    /// 数据访问过程的事件参数
    /// </summary>
    public class DbEventArgs : EventArgs
    {
        private DbCommand command;

        /// <summary>
        /// 需要抛出供外界访问或操作的命令对象
        /// </summary>
        public virtual DbCommand Command
        {
            get { return command; }
            set { command = value; }
        }
    }
}
