using System;
using System.Configuration;
namespace MarvellousWorks.PracticalPattern.BuilderPattern.Configurable
{
    /// <summary>
    /// 代表实际需要使用的标示产品每个特性的实体类型
    /// </summary>
    public class ConcreteFeatureConfigurationElement : ConfigurationElement
    {
        [ConfigurationProperty("type", IsRequired = true)]
        public virtual string TypeName { get { return (string)base["type"]; } }

        /// <summary>
        /// 配置元素同时作为工厂，创建一个“没加雕琢”过的产品特性实例毛坯
        /// </summary>
        /// <returns></returns>
        public IFeature Create()
        {
            return (IFeature)Activator.CreateInstance(Type.GetType(TypeName));
        }
    }
}
