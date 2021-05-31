using System;
using System.Configuration;
namespace MarvellousWorks.PracticalPattern.BuilderPattern.Configurable
{
    /// <summary>
    /// ����ĳ�������"feature"����Ԫ��
    /// </summary>
    public class FeatureConfigurationElement : NamedConfigurationElement
    {
        [ConfigurationProperty("description", DefaultValue = "")]
        public virtual string Description { get { return (string)this["description"]; } } 
    }

    /// <summary>
    /// ����ĳ�������"features"����Ԫ�ؼ���
    /// </summary>
    [ConfigurationCollection(typeof(FeatureConfigurationElement),
    CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap)]
    public class FeatureConfigurationElementCollection :
        NamedConfigurationElementCollection<FeatureConfigurationElement> { }
}
