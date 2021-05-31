using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.MementoPattern.SealClassic
{
    /// <summary>
    /// 为了便于定义抽象状态类型所定义的接口
    /// </summary>
    public interface IState { }

    /// <summary>
    /// 抽象备忘录对象接口
    /// </summary>
    public interface IMemento<T> where T : IState
    {
        T State { get; set;}
    }

    /// <summary>
    /// 包括内部备忘录类型的原发器抽象定义
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class OriginatorBase<T>
        where T : IState
    {
        /// <summary>
        /// 原发器对象的状态
        /// </summary>
        protected T state;

        /// <summary>
        /// 把备忘录定义为原发器的内部类型
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
        /// 把状态保存到备忘录
        /// </summary>
        public virtual void SaveCheckpoint() { m = CreateMemento(); }
        /// <summary>
        /// 从备忘录恢复之前的状态
        /// </summary>
        public virtual void Undo()
        {
            if(m == null) return;
            state = m.State;
        }
    }

    /// <summary>
    /// 具体状态类型
    /// </summary>
    public struct Position : IState
    {
        public int X;
        public int Y;
    }

    /// <summary>
    /// 具体原发器类型
    /// </summary>
    public class Originator : OriginatorBase<Position>
    {
        /// <summary>
        /// 供客户程序使用的非备忘录相关操作
        /// </summary>
        /// <param name="x"></param>
        public void UpdateX(int x) { base.state.X = x; }
        public void DecreaseX() { base.state.X--; }
        public void IncreaseY() { base.state.Y++; }
        public Position Current { get { return base.state; } }
    }
}
