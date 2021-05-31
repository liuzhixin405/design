using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.MementoPattern.Classic
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
    /// 抽象的原发器对象接口
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
        /// 原发器对象的状态
        /// </summary>
        protected T state;

        /// <summary>
        /// 把状态保存到备忘录，或者从备忘录恢复之前的状态
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
    /// 具体状态类型
    /// </summary>
    public struct Position : IState
    {
        public int X;
        public int Y;
    }

    /// <summary>
    /// 具体备忘录类型
    /// </summary>
    public class Memento : MementoBase<Position> { }


    /// <summary>
    /// 具体原发器类型
    /// </summary>
    public class Originator : OriginatorBase<Position, Memento>
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
