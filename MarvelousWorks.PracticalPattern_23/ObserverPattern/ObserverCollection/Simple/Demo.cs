using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.ObserverPattern.ObserverCollection.Simple
{
    /// <summary>
    /// 用于保存集合操作中操作条目信息的时间参数
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class DictionaryEventArgs<TKey, TValue> : EventArgs
    {
        private TKey key;
        private TValue value;

        public DictionaryEventArgs(TKey key, TValue value)
        {
            this.key = key;
            this.value = value;
        }

        public TKey Key { get { return key; } }
        public TValue Value { get { return value; } }
    }

    /// <summary>
    /// 具有操作事件的IDictionary<TKey, TValue>接口
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public interface IObserverableDictionary<TKey, TValue> :
        IDictionary<TKey, TValue>
    {
        EventHandler<DictionaryEventArgs<TKey, TValue>> NewItemAdded { get; set;}
    }

    /// <summary>
    /// 一种比较简单的实现方式
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class ObserverableDictionary<TKey, TValue> : 
        Dictionary<TKey, TValue>, IObserverableDictionary<TKey, TValue>
    {
        protected EventHandler<DictionaryEventArgs<TKey, TValue>> newItemAdded;
        public EventHandler<DictionaryEventArgs<TKey, TValue>> NewItemAdded
        {
            get { return newItemAdded; }
            set { newItemAdded = value; }
        }

        /// <summary>
        /// 为既有操作增加事件
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public new void Add(TKey key, TValue value)
        {
            base.Add(key, value);
            if (NewItemAdded != null)
                NewItemAdded(this, new DictionaryEventArgs<TKey, TValue>(key, value));
        }
    }
}
