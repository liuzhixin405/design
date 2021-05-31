using System;
using System.Configuration;
namespace MarvellousWorks.PracticalPattern.BuilderPattern.Configurable
{
    public class CustomProductConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("concreteFeature")]
        public ConcreteFeatureConfigurationElement ConcreteFeature
        {
            get { return (ConcreteFeatureConfigurationElement)base["concreteFeature"]; }
        }

        [ConfigurationProperty("products")]
        public ProductConfigurationElementCollection Products
        {
            get { return (ProductConfigurationElementCollection)base["products"]; }
        }
    }
}
