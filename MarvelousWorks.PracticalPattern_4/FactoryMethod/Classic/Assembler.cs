using System;
using System.Collections.Generic;
using System.Configuration;
using System.Collections.Specialized;
namespace MarvellousWorks.PracticalPattern.FactoryMethod.Classic
{
    public class Assembler
    {
        /// <summary>
        /// ���ý�����
        /// </summary>
        private const string SectionName =
            "marvellousWorks.practicalPattern.factoryMethod.customFactories";

        /// <summary>
        /// IFactory��QualifiedName����
        /// </summary>
        private const string FactoryTypeName = "IFactory";

        /// <summary>
        /// ���桰��������/ʵ�����͡���Ӧ��ϵ���ֵ�
        /// </summary>
        private static Dictionary<Type, Type> dictionary = new Dictionary<Type, Type>();

        static Assembler()
        {
            // ͨ�������ļ�������ء������Ʒ���͡�/ ��ʵ���Ʒ���͡�ӳ���ϵ
            NameValueCollection collection =
                (NameValueCollection)ConfigurationSettings.GetConfig(SectionName);
            for (int i = 0; i < collection.Count; i++)
            {
                string target = collection.GetKey(i);
                string source = collection[i];
                dictionary.Add(Type.GetType(target), Type.GetType(source));
            }
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
