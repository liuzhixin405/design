using System;
using System.Collections.Generic;
using System.Configuration;
namespace MarvellousWorks.PracticalPattern.Common
{
    /// <summary>
    /// 集中的配置文件信息访问Broker
    /// </summary>
    public static class ConfigurationBroker
    {
        #region Fields
        /// <summary>
        /// 用于保存所有需要登记的通过配置获取的类型实体， 使用线程安全的内存缓冲对象保存。
        /// </summary>
        private static readonly GenericCache<Type, object> cache;
        #endregion

        static ConfigurationBroker()
        {
            System.Configuration.Configuration config = 
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            cache = new GenericCache<Type, object>();
            // 查找自定义的 IConfigurationSource 配置节组，并调用 Load方法加载配置缓冲对象
            foreach (ConfigurationSectionGroup group in config.SectionGroups)
                if (typeof(IConfigurationSource).IsAssignableFrom(group.GetType()))
                    ((IConfigurationSource)group).Load();
        }

        /// <summary>
        /// 各配置项将客户程序需要使用的配置对象通过该方法缓存。
        /// </summary>
        /// <param name="type">配置对象的类型</param>
        /// <param name="item">实际的配置对象实例</param>
        public static void Add(Type type, object item)
        {
            if((type == null) || (item == null)) throw new NullReferenceException();
            cache.Add(type, item);
        }
        public static void Add(KeyValuePair<Type, object> item){Add(item.Key, item.Value);}
        public static void Add(object item){Add(item.GetType(), item);}


        /// <summary>
        /// 获取缓冲的配置对象。
        /// </summary>
        /// <param name="type">配置对象的类型</param>
        /// <returns>实际的配置对象实例</returns>
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
