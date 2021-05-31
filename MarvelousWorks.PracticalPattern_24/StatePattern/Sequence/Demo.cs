using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.StatePattern.Sequence
{
    /// <summary>
    /// �����״̬�ӿ�
    /// </summary>
    public interface IState
    {
        void Open(ContextBase context);
        void Close(ContextBase context);
        void Query(ContextBase context);
    }

    /// <summary>
    /// �����Context����
    /// </summary>
    public abstract class ContextBase
    {
        /// <summary>
        /// ʵ�ʿ��ƴ����״̬����
        /// </summary>
        private IState state;
        public virtual IState State
        {
            get { return state; }
            set { state = value; }
        }

        public virtual ContextBase Open() 
        {
            state.Open(this);
            return this;
        }
        public virtual ContextBase Close() 
        {
            state.Close(this);
            return this;
        }
        public virtual ContextBase Query()
        {
            state.Query(this);
            return this;
        }
    }
}
