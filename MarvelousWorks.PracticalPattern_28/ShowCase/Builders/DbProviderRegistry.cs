using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
namespace MarvellousWorks.PracticalPattern.ShowCase.Builders
{
    /// <summary>
    /// DbProvider�����Database���͵�ע�������
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
        /// ��ȡָ��providerName��Ӧ��Database����
        /// </summary>
        /// <param name="providerName">DbProvider����</param>
        /// <returns>��Ӧ�ľ���Database����</returns>
        public string GetDbType(string providerName)
        {
            return collection[providerName];
        }
    }
}
