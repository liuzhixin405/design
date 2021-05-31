using System;
using System.Collections.Generic;
using MarvellousWorks.PracticalPattern.CommandPattern.Classic;
namespace MarvellousWorks.PracticalPattern.CommandPattern.Async
{
    /// <summary>
    /// ����Commandģʽ�µ�Command������
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// �ṩ�������ߵ�ͳһ��������
        /// </summary>
        void Execute();
    }

    /// <summary>
    /// ��չ������첽���õ�Command����
    /// ����Ϊ�˼򻯣�ֻ������Execute�����������֪ͨ
    /// </summary>
    public interface IAsyncCommand : ICommand
    {
        /// <summary>
        /// �����첽���õ��¼�
        /// </summary>
        event AsyncCallback AsyncCompleted;
        /// <summary>
        /// ����ͬ�����õ��¼�
        /// </summary>
        event EventHandler Completed;

        /// <summary>
        /// �����첽���õ�Command���󷽷�
        /// </summary>
        void AsyncExecute();
    }

    /// <summary>
    /// Command����ĳ������
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
