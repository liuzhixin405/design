using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.IteratorPattern.Pure
{
    public interface IAggregate
    {
        void Add(string message);
        /// <summary>
        /// 相当于CreateIterator()方法
        /// </summary>
        /// <returns></returns>
        IEnumerator<string> GetEnumerator();
    }

    public class Aggregate : IAggregate
    {
        public const int Max = 5;
        private string[] messages = new string[Max];
        private int capacity = 0;

        public void Add(string message)
        {
            if (capacity == Max) throw new IndexOutOfRangeException();
            messages[capacity++] = message;
        }

        public IEnumerator<string> GetEnumerator()
        {
            for (int i = 0; i < capacity; i++)
                yield return messages[i];
        }
    }
}
