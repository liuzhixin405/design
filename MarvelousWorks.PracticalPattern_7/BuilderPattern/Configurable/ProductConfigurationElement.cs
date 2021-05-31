using System;
using System.Collections.Generic;
using System.Configuration;
namespace MarvellousWorks.PracticalPattern.BuilderPattern.Configurable
{
    /// <summary>
    /// ����ĳ�������"product"����Ԫ��
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
        /// ����Ԫ��ͬʱ��Ϊ����������һ����û�ӵ��������Ĳ�Ʒʵ��ë��
        /// </summary>
        /// <returns></returns>
        public IProduct Create() 
        {
            return (IProduct)Activator.CreateInstance(Type.GetType(TypeName)); 
        }
    }

    /// <summary>
    /// ����ĳ�������"products"����Ԫ�ؼ���
    /// </summary>
    [ConfigurationCollection(typeof(ProductConfigurationElement),
    CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap)]
    public class ProductConfigurationElementCollection :
        NamedConfigurationElementCollection<ProductConfigurationElement> { }
}
