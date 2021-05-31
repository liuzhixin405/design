using System;
using System.Collections.Generic;
using System.Configuration;
namespace MarvellousWorks.PracticalPattern.BuilderPattern.Configurable
{
    /// <summary>
    /// 用于读取配置文件的类型
    /// </summary>
    public static class ConfigurationBroker
    {
        private const string groupName = "marvellousWorks.practicalPattern.builder";
        private const string sectionName = "customProducts";

        /// <summary>
        /// 需要使用的feature配置元素
        /// </summary>
        private static ConcreteFeatureConfigurationElement feature;
        /// <summary>
        /// 所有产品类型的配置集合
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
        /// 按照配置要求，获取某一个产品的配置信息
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
        /// 按照配置要求，创建一个产品特性（Feature）对象的实例
        /// </summary>
        /// <returns></returns>
        public static IFeature CreateFeature() { return feature.Create(); }
    }
}
