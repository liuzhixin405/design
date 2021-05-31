using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.MementoPattern.SealClassic
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

    /// <summary>
    /// �����ڲ�����¼���͵�ԭ����������
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class OriginatorBase<T>
        where T : IState
    {
        /// <summary>
        /// ԭ���������״̬
        /// </summary>
        protected T state;

        /// <summary>
        /// �ѱ���¼����Ϊԭ�������ڲ�����
        /// </summary>
        /// <typeparam name="T"></typeparam>
        protected class InternalMemento<T> : IMemento<T>
            where T : IState
        {
            private T state;
            public T State 
            {
                get { return state; }
                set { state = value; }
            }
        }

        protected virtual IMemento<T> CreateMemento()
        {
            IMemento<T> m = new InternalMemento<T>();
            m.State = this.state;
            return m;
        }

        private IMemento<T> m;
        /// <summary>
        /// ��״̬���浽����¼
        /// </summary>
        public virtual void SaveCheckpoint() { m = CreateMemento(); }
        /// <summary>
        /// �ӱ���¼�ָ�֮ǰ��״̬
        /// </summary>
        public virtual void Undo()
        {
            if(m == null) return;
            state = m.State;
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
    /// ����ԭ��������
    /// </summary>
    public class Originator : OriginatorBase<Position>
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
