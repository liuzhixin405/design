using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
namespace MarvellousWorks.PracticalPattern.ShowCase.Builders
{
    /// <summary>
    /// 方式机制内部管理连接信息的对象
    /// </summary>
    static class ConnectionManager
    {
        private const string ConnectionStringBuilderItem = 
            @"marvellousWorks.practicalPattern.shwoCase/connectionBuilders";
        private static IDictionary<string, ConnectionStringSettings> registry;

        static ConnectionManager()
        {
            NameValueCollection collection = (NameValueCollection)
                (ConfigurationManager.GetSection(ConnectionStringBuilderItem));
            ConnectionStringBuilder builder = new ConnectionStringBuilder(collection);
            registry = builder.BuildUp();
        }

        /// <summary>
        /// 获得处理后每个逻辑连接的配置信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static ConnectionStringSettings GetSetting(string name)
        {
            return registry[name];
        }
    }
}
