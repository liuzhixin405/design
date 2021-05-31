using System;
using System.Collections.Generic;
using System.Configuration;
namespace MarvellousWorks.PracticalPattern.ShowCase.DataIndependent.OO
{
    /// <summary>
    /// 生成Database对象的工厂类
    /// 通过静态类实现Singleton
    /// </summary>
    public static class DatabaseFactory
    {
        private static DbProviderRegistry registry = new DbProviderRegistry();

        /// <summary>
        /// 提供Database对象的工厂方法
        /// </summary>
        /// <param name="name">数据库逻辑名称</param>
        /// <returns>Database对象</returns>
        public static Database Create(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("name");
            string providerName = 
                ConfigurationManager.ConnectionStrings[name].ProviderName;
            Type type = Type.GetType(registry.GetDbType(providerName));
            return (Database)Activator.CreateInstance(type, name);
        }
    }
}
