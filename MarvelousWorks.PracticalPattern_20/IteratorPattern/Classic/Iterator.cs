using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.IteratorPattern.Classic
{
    /// <summary>
    /// ����������ӿ�
    /// </summary>
    public interface IIterator
    {
        /// <summary>
        /// Ϊ�˼򻯣�ֻ������Next����
        /// </summary>
        /// <returns></returns>
        string Next(); 
    }

    /// <summary>
    /// ����ۺ϶���ӿ�
    /// </summary>
    public interface IAggregate
    {
        /// <summary>
        /// �ۺϵ���������
        /// </summary>
        string[] Messages { get;}

        /// <summary>
        /// ���ϲ���
        /// </summary>
        /// <param name="message"></param>
        void Add(string message);

        /// <summary>
        /// Ϊ�ͻ������ṩ�������ķ���
        /// </summary>
        /// <returns></returns>
        IIterator CreaetIterator();
    }

    /// <summary>
    /// ����ۺ϶���
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
    /// �������������
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
