using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.DecoratorPattern.Refershable
{
    public interface IText
    {
        string Content { get;}
    }

    /// <summary>
    /// 定义每个Decorator会影响的内容
    /// </summary>
    public interface IState
    {
        /// <summary>
        /// 比较新定义的状态是否与现有的状态一致
        /// </summary>
        /// <param name="newState"></param>
        /// <returns></returns>
        bool Equals(IState newState);
    }

    public interface IDecorator : IText 
    {
        /// <summary>
        /// 记录当前Decorator需要维护的状态信息
        /// </summary>
        IState State { get; set;}

        /// <summary>
        /// 用于更新Decorator的方法
        /// 类型参数T主要用于定位具体匹配的Decorator对象
        /// </summary>
        /// <param name="newState"></param>
        void Refresh<T>(IState newState) where T : IDecorator; 
    }

    public abstract class DecoratorBase : IDecorator    // is a
    {
        /// <summary>
        /// has a 
        /// </summary>
        protected IText target;
        public DecoratorBase(IText target) { this.target = target; }

        public abstract string Content { get;}

        /// <summary>
        /// 有关Decorator状态的属性及更新操作
        /// </summary>
        protected IState state;
        public virtual IState State
        {
            get { return this.state; }
            set { this.state = value; }
        }
        public virtual void Refresh<T>(IState newState) where T : IDecorator
        {
            if (this.GetType() == typeof(T))
            {
                if(newState == null) State = null;
                if((State != null) && (!State.Equals(newState)))
                    State = newState;
                return;
            }
            // 通过递归继续寻找与T匹配的Decorator类型
            if (target != null)
                ((IDecorator)target).Refresh<T>(newState);
        }
    }
}
