using System;
using System.Collections.Generic;
using System.Configuration;
namespace MarvellousWorks.PracticalPattern.BuilderPattern.Configurable
{
    /// <summary>
    /// ���ڶ�ȡ�����ļ�������
    /// </summary>
    public static class ConfigurationBroker
    {
        private const string groupName = "marvellousWorks.practicalPattern.builder";
        private const string sectionName = "customProducts";

        /// <summary>
        /// ��Ҫʹ�õ�feature����Ԫ��
        /// </summary>
        private static ConcreteFeatureConfigurationElement feature;
        /// <summary>
        /// ���в�Ʒ���͵����ü���
        /// </summary>
        private static ProductConfigurationElementCollection products;

        static ConfigurationBroker()
        {
            Configuration configuration = 
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            CustomProductConfigurationSection section =
                (CustomProductConfigurationSection)
                configuration.GetSectionGroup(groupName).Sections[sectionName];
            feature = section.ConcreteFeature;
            products = section.Products;
        }

        /// <summary>
        /// ��������Ҫ�󣬻�ȡĳһ����Ʒ��������Ϣ
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static ProductConfigurationElement GetConfiguration(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("name");
            if (!products.ContainsKey(name)) return null;
            return products[name];
        }

        /// <summary>
        /// ��������Ҫ�󣬴���һ����Ʒ���ԣ�Feature�������ʵ��
        /// </summary>
        /// <returns></returns>
        public static IFeature CreateFeature() { return feature.Create(); }
    }
}
