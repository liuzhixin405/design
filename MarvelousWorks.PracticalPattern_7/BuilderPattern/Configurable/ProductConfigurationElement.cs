using System;
using System.Collections.Generic;
using System.Configuration;
namespace MarvellousWorks.PracticalPattern.BuilderPattern.Configurable
{
    /// <summary>
    /// 代表某个具体的"product"配置元素
    /// </summary>
    public class ProductConfigurationElement : NamedConfigurationElement
    {
        [ConfigurationProperty("price", DefaultValue = "0")]
        public virtual double Price { get { return (double)this["price"]; } }

        [ConfigurationProperty("type", IsRequired=true)]
        public virtual string TypeName { get { return (string)this["type"]; } }

        [ConfigurationProperty("features")]
        public FeatureConfigurationElementCollection Features
        {
            get { return base["features"] as FeatureConfigurationElementCollection; }
        }

        /// <summary>
        /// 配置元素同时作为工厂，创建一个“没加雕琢”过的产品实例毛坯
        /// </summary>
        /// <returns></returns>
        public IProduct Create() 
        {
            return (IProduct)Activator.CreateInstance(Type.GetType(TypeName)); 
        }
    }

    /// <summary>
    /// 代表某个具体的"products"配置元素集合
    /// </summary>
    [ConfigurationCollection(typeof(ProductConfigurationElement),
    CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap)]
    public class ProductConfigurationElementCollection :
        NamedConfigurationElementCollection<ProductConfigurationElement> { }
}
