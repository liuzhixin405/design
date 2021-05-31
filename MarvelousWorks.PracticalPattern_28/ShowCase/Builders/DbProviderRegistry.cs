using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
namespace MarvellousWorks.PracticalPattern.ShowCase.Builders
{
    /// <summary>
    /// DbProvider与具体Database类型的注册表类型
    /// </summary>
    public class DbProviderRegistry
    {
        private const string GroupName = "marvellousWorks.practicalPattern.shwoCase";
        private const string SectionName = "dbProviderMappings";
        private static NameValueCollection collection;

        static DbProviderRegistry()
        {
            collection = (NameValueCollection)
                ConfigurationManager.GetSection(GroupName + "/" + SectionName);
        }

        /// <summary>
        /// 获取指定providerName对应的Database类型
        /// </summary>
        /// <param name="providerName">DbProvider名称</param>
        /// <returns>对应的具体Database类型</returns>
        public string GetDbType(string providerName)
        {
            return collection[providerName];
        }
    }
}
