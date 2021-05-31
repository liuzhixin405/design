using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.MementoPattern.Classic
{
    /// <summary>
    /// Ϊ�˱��ڶ������״̬����������Ľӿ�
    /// </summary>
    public interface IState { }

    /// <summary>
    /// ������¼����ӿ�
    /// </summary>
    public interface IMemento<T> where T : IState
    {
        T State { get; set;}
    }

    public abstract class MementoBase<T> : IMemento<T>
        where T : IState
    {
        protected T state;

        public virtual T State
        {
            get { return state; }
            set { state = value; }
        }
    }

    /// <summary>
    /// �����ԭ��������ӿ�
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// /// <typeparam name="M"></typeparam>
    public interface IOriginator<T, M>
        where T : IState
        where M : IMemento<T>, new()
    {
        IMemento<T> Memento { get;}// set;}
    }

    public abstract class OriginatorBase<T, M>
        where T : IState
        where M : IMemento<T>, new()
    {
        /// <summary>
        /// ԭ���������״̬
        /// </summary>
        protected T state;

        /// <summary>
        /// ��״̬���浽����¼�����ߴӱ���¼�ָ�֮ǰ��״̬
        /// </summary>
        public virtual IMemento<T> Memento
        {
            get
            {
                M m = new M();
                m.State = this.state;
                return m;
            }
            set
            {
                if (value == null) throw new ArgumentNullException();
                this.state = value.State;
            }
        }
    }


    /// <summary>
    /// ����״̬����
    /// </summary>
    public struct Position : IState
    {
        public int X;
        public int Y;
    }

    /// <summary>
    /// ���屸��¼����
    /// </summary>
    public class Memento : MementoBase<Position> { }


    /// <summary>
    /// ����ԭ��������
    /// </summary>
    public class Originator : OriginatorBase<Position, Memento>
    {
        /// <summary>
        /// ���ͻ�����ʹ�õķǱ���¼��ز���
        /// </summary>
        /// <param name="x"></param>
        public void UpdateX(int x) { base.state.X = x; }
        public void DecreaseX() { base.state.X--; }
        public void IncreaseY() { base.state.Y++; }
        public Position Current { get { return base.state; } }
    }
}
