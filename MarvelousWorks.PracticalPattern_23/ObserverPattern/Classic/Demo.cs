using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.ObserverPattern.Classic
{
    /// <summary>
    /// �۲������ͽӿ�
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IObserver<T>
    {
        void Update(SubjectBase<T> subject);
    }


    /// <summary>
    /// Ŀ������������
    /// </summary>
    public abstract class SubjectBase<T> 
    {
        /// <summary>
        /// �Ǽ�������Ҫ֪ͨ�Ĺ۲���
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
        /// ���¸��۲���
        /// </summary>
        public virtual void Notify()
        {
            foreach (IObserver<T> observer in observers)
                observer.Update(this);
        }

        /// <summary>
        /// ���ͻ������Ŀ�������в����ķ���
        /// </summary>
        /// <param name="state"></param>
        public virtual void Update(T state)
        {
            this.state = state;
            Notify();   // ��������֪ͨ
        }
    }

    /// <summary>
    /// ����Ŀ������
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SubjectA<T> : SubjectBase<T> { }
    public class SubjectB<T> : SubjectBase<T> { }

    /// <summary>
    /// ����۲�������
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
