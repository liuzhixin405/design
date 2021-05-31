using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
namespace MarvellousWorks.PracticalPattern.Concept.Iterating
{
    public class CompositeIterator
    {
        // Ϊÿ�����Ա��������ṩ������
        // ��������Ϊ object ������ CompositeIterator ����Ҳ����Ƕ��
        private IDictionary<object, IEnumerator> items = new Dictionary<object, IEnumerator>();
        public void Add(object data) { items.Add(data, GetEnumerator(data)); }

        // �����ṩ���Ա����� IEnumerator
        public IEnumerator GetEnumerator()
        {
            if ((items != null) && (items.Count > 0))
                foreach (IEnumerator item in items.Values)
                    while (item.MoveNext()) 
                        yield return item.Current;
        }

        // ��ȡ IEnumerator 
        public static IEnumerator GetEnumerator(object data)
        {
            if (data == null) throw new NullReferenceException();
            Type type = data.GetType();

            // �Ƿ�Ϊ Stack
            if (type.IsAssignableFrom(typeof(Stack))
                || type.IsAssignableFrom(typeof(Stack<ObjectWithName>)))
                return DynamicInvokeEnumerator(data);

            // �Ƿ�Ϊ Queue
            if (type.IsAssignableFrom(typeof(Queue))
                || type.IsAssignableFrom(typeof(Queue<ObjectWithName>)))
                return DynamicInvokeEnumerator(data);

            // �Ƿ�Ϊ Array
            if ((type.IsArray) && (type.GetElementType().IsAssignableFrom(typeof(ObjectWithName))))
                return ((ObjectWithName[])data).GetEnumerator();

            // �Ƿ�Ϊ������
            if (type.IsAssignableFrom(typeof(BinaryTreeNode)))
                return ((BinaryTreeNode)data).GetEnumerator();

            throw new NotSupportedException();
        }

        // ͨ�����䶯̬�������ʵ���� GetEnumerator ������ȡ IEnumerator
        private static IEnumerator DynamicInvokeEnumerator(object data)
        {
            if (data == null) throw new NullReferenceException();
            Type type = data.GetType();
            return (IEnumerator)type.InvokeMember("GetEnumerator", 
                BindingFlags.InvokeMethod, null, data, null);
        }
    }
}
