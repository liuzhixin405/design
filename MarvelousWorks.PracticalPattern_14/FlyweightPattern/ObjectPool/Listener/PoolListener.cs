#region using
using System;
using System.Collections.Generic;
using System.Text;

using MarvellousWorks.PracticalPattern.FlyweightPattern.ObjectPool;
using MarvellousWorks.PracticalPattern.FlyweightPattern.ObjectPool.Dispatch;
#endregion
namespace MarvellousWorks.PracticalPattern.FlyweightPattern.ObjectPool.Listener
{
    /// <summary>
    /// 提供客户程序访问对象池的侦听器对象
    /// </summary>
    public sealed class PoolListener<T>
        where T : PoolableBase, new()
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public PoolListener() { }

        /// <summary>
        /// 由侦听器代理获取对象实例
        /// </summary>
        /// <returns></returns>
        public T Acquire()
        {
            if (ObjectDispatch.Available)
                return ObjectDispatch.Acquire<T>();
            else
                return null;
        }
    }
}
