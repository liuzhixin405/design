using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.StatePattern.Sequence
{
    /// <summary>
    /// 抽象的状态接口
    /// </summary>
    public interface IState
    {
        void Open(ContextBase context);
        void Close(ContextBase context);
        void Query(ContextBase context);
    }

    /// <summary>
    /// 抽象的Context对象
    /// </summary>
    public abstract class ContextBase
    {
        /// <summary>
        /// 实际控制处理的状态对象
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
