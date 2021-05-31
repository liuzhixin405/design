using System;
using System.Collections.Generic;

namespace MarvellousWorks.PracticalPattern.MementoPattern.Persistence
{
    /// <summary>
    /// 为了便于定义抽象状态类型所定义的接口
    /// </summary>
    public interface IState { }

    /// <summary>
    /// 定义保存备忘信息的持久对象抽象接口
    /// 由于持久对象往往会服务于多个原发器对象，
    /// 因此为了区分不同实例的备忘内容，保存的时候需要提供：
    /// 1、原发器对象标识
    /// 2、备忘信息版本
    /// 3、状态信息
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPersistenceStore<T>
        where T : IState
    {
        void Store(string originatorID, int version, T target);
        T Find(string originatorID, int version);
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
        /// 用于标示原发器对象的标识
        /// </summary>
        protected string key;
        public OriginatorBase() { key = (new Guid()).ToString(); }

        /// <summary>
        /// 待注入的持久机制
        /// </summary>
        protected IPersistenceStore<T> store;

        /// <summary>
        /// 把状态保存到备忘录
        /// </summary>
        public virtual void SaveCheckpoint(int version)
        {
            store.Store(key, version, state);
        }

        /// <summary>
        /// 从备忘录恢复之前的状态
        /// </summary>
        public virtual void Undo(int version)
        {
            state = store.Find(key, version);
        }
    }

    /// <summary>
    /// 具体状态类型
    /// </summary>
    [Serializable]
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
        public Originator() 
        {
            store = new MementoPersistenceStore<Position>(); 
        }

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
