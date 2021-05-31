using System;
using System.Configuration;
namespace MarvellousWorks.PracticalPattern.BuilderPattern.Configurable
{
    /// <summary>
    /// 代表某个具体的"feature"配置元素
    /// </summary>
    public class FeatureConfigurationElement : NamedConfigurationElement
    {
        [ConfigurationProperty("description", DefaultValue = "")]
        public virtual string Description { get { return (string)this["description"]; } } 
    }

    /// <summary>
    /// 代表某个具体的"features"配置元素集合
    /// </summary>
    [ConfigurationCollection(typeof(FeatureConfigurationElement),
    CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap)]
    public class FeatureConfigurationElementCollection :
        NamedConfigurationElementCollection<FeatureConfigurationElement> { }
}
