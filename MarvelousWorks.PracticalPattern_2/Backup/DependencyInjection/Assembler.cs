using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.Concept.DependencyInjection
{
    public class Assembler
    {
        /// <summary>
        /// ���桰��������/ʵ�����͡���Ӧ��ϵ���ֵ�
        /// </summary>
        private static Dictionary<Type, Type> dictionary = new Dictionary<Type, Type>();

        static Assembler()
        {
            // ע�����������Ҫʹ�õ�ʵ������
            // ʵ�ʵ�������Ϣ���Դ������ƻ��,����ͨ�����ö���.
            dictionary.Add(typeof(ITimeProvider), typeof(SystemTimeProvider));
        }

        /// <summary>
        /// ���ݿͻ�������Ҫ�ĳ�������ѡ����Ӧ��ʵ�����ͣ�����������ʵ��
        /// </summary>
        /// <typeparam name="T">�������ͣ�������/�ӿ�/����ĳ�ֻ��ࣩ</typeparam>
        /// <returns>ʵ������ʵ��</returns>
        public object Create(Type type)     // ��Ҫ���ڷǷ��ͷ�ʽ����
        {
            if ((type == null) || !dictionary.ContainsKey(type)) throw new NullReferenceException();
            Type targetType = dictionary[type];
            return Activator.CreateInstance(targetType);
        }

        /// <typeparam name="T">�������ͣ�������/�ӿ�/����ĳ�ֻ��ࣩ</typeparam>
        public T Create<T>()    // ��Ҫ���ڷ��ͷ�ʽ����
        {
            return (T)Create(typeof(T));
        }
    }
}
