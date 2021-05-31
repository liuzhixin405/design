using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.IteratorPattern.Classic
{
    /// <summary>
    /// 抽象迭代器接口
    /// </summary>
    public interface IIterator
    {
        /// <summary>
        /// 为了简化，只保留了Next方法
        /// </summary>
        /// <returns></returns>
        string Next(); 
    }

    /// <summary>
    /// 抽象聚合对象接口
    /// </summary>
    public interface IAggregate
    {
        /// <summary>
        /// 聚合的数据内容
        /// </summary>
        string[] Messages { get;}

        /// <summary>
        /// 集合操作
        /// </summary>
        /// <param name="message"></param>
        void Add(string message);

        /// <summary>
        /// 为客户程序提供迭代器的方法
        /// </summary>
        /// <returns></returns>
        IIterator CreaetIterator();
    }

    /// <summary>
    /// 具体聚合对象
    /// </summary>
    public class Aggregate : IAggregate
    {
        public const int Max = 5;
        private string[] messages = new string[Max];
        public string[] Messages { get { return messages; } }
        private int capacity = 0;
        public int Capacity { get { return capacity; } }

        public void Add(string message)
        {
            if (capacity == Max) throw new IndexOutOfRangeException();
            messages[capacity++] = message;
        }

        public IIterator CreaetIterator(){return new Iterator(this);}
    }

    /// <summary>
    /// 具体迭代器对象
    /// </summary>
    public class Iterator : IIterator
    {
        private Aggregate aggregate;
        private int index;
        public Iterator(Aggregate aggregate) 
        {
            this.aggregate = aggregate;
            index = 0;
        }

        public string Next()
        {
            if (index == aggregate.Capacity) throw new IndexOutOfRangeException();
            return aggregate.Messages[index++];
        }
    }
}
