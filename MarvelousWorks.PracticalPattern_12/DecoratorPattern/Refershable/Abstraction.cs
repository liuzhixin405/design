using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.DecoratorPattern.Refershable
{
    public interface IText
    {
        string Content { get;}
    }

    /// <summary>
    /// ����ÿ��Decorator��Ӱ�������
    /// </summary>
    public interface IState
    {
        /// <summary>
        /// �Ƚ��¶����״̬�Ƿ������е�״̬һ��
        /// </summary>
        /// <param name="newState"></param>
        /// <returns></returns>
        bool Equals(IState newState);
    }

    public interface IDecorator : IText 
    {
        /// <summary>
        /// ��¼��ǰDecorator��Ҫά����״̬��Ϣ
        /// </summary>
        IState State { get; set;}

        /// <summary>
        /// ���ڸ���Decorator�ķ���
        /// ���Ͳ���T��Ҫ���ڶ�λ����ƥ���Decorator����
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
        /// �й�Decorator״̬�����Լ����²���
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
            // ͨ���ݹ����Ѱ����Tƥ���Decorator����
            if (target != null)
                ((IDecorator)target).Refresh<T>(newState);
        }
    }
}
