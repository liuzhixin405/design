using System;
using System.Collections.Generic;
using System.Configuration;
namespace MarvellousWorks.PracticalPattern.Common
{
    /// <summary>
    /// ���е������ļ���Ϣ����Broker
    /// </summary>
    public static class ConfigurationBroker
    {
        #region Fields
        /// <summary>
        /// ���ڱ���������Ҫ�Ǽǵ�ͨ�����û�ȡ������ʵ�壬 ʹ���̰߳�ȫ���ڴ滺����󱣴档
        /// </summary>
        private static readonly GenericCache<Type, object> cache;
        #endregion

        static ConfigurationBroker()
        {
            System.Configuration.Configuration config = 
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            cache = new GenericCache<Type, object>();
            // �����Զ���� IConfigurationSource ���ý��飬������ Load�����������û������
            foreach (ConfigurationSectionGroup group in config.SectionGroups)
                if (typeof(IConfigurationSource).IsAssignableFrom(group.GetType()))
                    ((IConfigurationSource)group).Load();
        }

        /// <summary>
        /// ��������ͻ�������Ҫʹ�õ����ö���ͨ���÷������档
        /// </summary>
        /// <param name="type">���ö��������</param>
        /// <param name="item">ʵ�ʵ����ö���ʵ��</param>
        public static void Add(Type type, object item)
        {
            if((type == null) || (item == null)) throw new NullReferenceException();
            cache.Add(type, item);
        }
        public static void Add(KeyValuePair<Type, object> item){Add(item.Key, item.Value);}
        public static void Add(object item){Add(item.GetType(), item);}


        /// <summary>
        /// ��ȡ��������ö���
        /// </summary>
        /// <param name="type">���ö��������</param>
        /// <returns>ʵ�ʵ����ö���ʵ��</returns>
        public static T GetConfigurationObject<T>()
            where T : class
        {
            if (cache.Count <= 0) return null;
            object result;
            if (!cache.TryGetValue(typeof(T), out result))
                return null;
            else
                return (T)result;
        }
    }
}
