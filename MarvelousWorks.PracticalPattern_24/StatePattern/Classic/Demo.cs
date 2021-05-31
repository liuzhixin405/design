using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.StatePattern.Classic
{
    /// <summary>
    /// 抽象的状态接口
    /// </summary>
    public interface IState
    {
        void Open();
        void Close();
        void Query();
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

        public virtual void Open() { state.Open(); }
        public virtual void Close() { state.Close(); }
        public virtual void Query() { state.Query(); }
    }
}
