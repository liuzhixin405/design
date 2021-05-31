using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.ObserverPattern.Classic
{
    /// <summary>
    /// 观察者类型接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IObserver<T>
    {
        void Update(SubjectBase<T> subject);
    }


    /// <summary>
    /// 目标对象抽象类型
    /// </summary>
    public abstract class SubjectBase<T> 
    {
        /// <summary>
        /// 登记所有需要通知的观察者
        /// </summary>
        protected IList<IObserver<T>> observers = new List<IObserver<T>>();
        protected T state;
        public virtual T State{get{return state;}}

        /// <summary>
        /// Attach
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="observer"></param>
        /// <returns></returns>
        public static SubjectBase<T> operator +(SubjectBase<T> subject, IObserver<T> observer)
        {
            subject.observers.Add(observer);
            return subject;
        }
        /// <summary>
        /// Detach
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="observer"></param>
        /// <returns></returns>
        public static SubjectBase<T> operator -(SubjectBase<T> subject, IObserver<T> observer)
        {
            subject.observers.Remove(observer);
            return subject;
        }

        /// <summary>
        /// 更新各观察者
        /// </summary>
        public virtual void Notify()
        {
            foreach (IObserver<T> observer in observers)
                observer.Update(this);
        }

        /// <summary>
        /// 供客户程序对目标对象进行操作的方法
        /// </summary>
        /// <param name="state"></param>
        public virtual void Update(T state)
        {
            this.state = state;
            Notify();   // 触发对外通知
        }
    }

    /// <summary>
    /// 具体目标类型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SubjectA<T> : SubjectBase<T> { }
    public class SubjectB<T> : SubjectBase<T> { }

    /// <summary>
    /// 具体观察者类型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Observer<T> : IObserver<T>
    {
        public T State;
        public void Update(SubjectBase<T> subject)
        {
            this.State = subject.State;   
        }
    }
}
