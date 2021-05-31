using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
namespace MarvellousWorks.PracticalPattern.ShowCase.Builders
{
    /// <summary>
    /// ��ʽ�����ڲ�����������Ϣ�Ķ���
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
        /// ��ô����ÿ���߼����ӵ�������Ϣ
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static ConnectionStringSettings GetSetting(string name)
        {
            return registry[name];
        }
    }
}
