using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.TemplatePattern.Generics
{
    /// <summary>
    /// ��ʾ��������ݽṹ, ���㷨�ṹ��Թ̶��������Ͳ���<T>�ɱ�
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TemplateList<T> 
    {
        private class Node
        {
            public T Data;
            public Node Next;
            public Node(T data)
            {
                this.Data = data;
                Next = null;
            }
        }

        private Node head = null;
        /// <summary>
        /// ������ͷ�����µĽڵ�
        /// </summary>
        /// <param name="data"></param>
        public void Add(T data)
        {
            Node node = new Node(data);
            node.Next = head;
            head = node;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
