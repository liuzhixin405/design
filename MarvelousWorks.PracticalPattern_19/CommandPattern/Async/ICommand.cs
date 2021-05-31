using System;
using System.Collections.Generic;
using MarvellousWorks.PracticalPattern.CommandPattern.Classic;
namespace MarvellousWorks.PracticalPattern.CommandPattern.Async
{
    /// <summary>
    /// 经典Command模式下的Command对象定义
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// 提供给调用者的统一操作方法
        /// </summary>
        void Execute();
    }

    /// <summary>
    /// 扩展后具有异步调用的Command对象
    /// 这里为了简化，只保留了Execute方法结束后的通知
    /// </summary>
    public interface IAsyncCommand : ICommand
    {
        /// <summary>
        /// 用于异步调用的事件
        /// </summary>
        event AsyncCallback AsyncCompleted;
        /// <summary>
        /// 用于同步调用的事件
        /// </summary>
        event EventHandler Completed;

        /// <summary>
        /// 用于异步调用的Command对象方法
        /// </summary>
        void AsyncExecute();
    }

    /// <summary>
    /// Command对象的抽象基类
    /// </summary>
    public abstract class CommandBase : IAsyncCommand
    {
        public event AsyncCallback AsyncCompleted;
        public event EventHandler Completed;

        protected bool isAsync = false;

        public virtual void Execute()
        {
            if ((Completed != null) && (!isAsync))
                Completed(this, EventArgs.Empty);
        }

        public virtual void AsyncExecute()
        {
            if ((AsyncCompleted != null) && (Completed != null))
            {
                isAsync = true;
                Completed.BeginInvoke(this, EventArgs.Empty, AsyncCompleted, null);
            }
            Execute();
            isAsync = false;
        }
    }
}
