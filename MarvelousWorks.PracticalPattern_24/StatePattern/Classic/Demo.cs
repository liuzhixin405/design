using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.StatePattern.Classic
{
    /// <summary>
    /// �����״̬�ӿ�
    /// </summary>
    public interface IState
    {
        void Open();
        void Close();
        void Query();
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

        public virtual void Open() { state.Open(); }
        public virtual void Close() { state.Close(); }
        public virtual void Query() { state.Query(); }
    }
}
