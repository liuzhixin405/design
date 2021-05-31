using System;
namespace MarvellousWorks.PracticalPattern.BuilderPattern.Configurable
{
    public interface IBuilder
    {
        IProduct Create(string name);
        void BuildPart(FeatureConfigurationElement config);
    }


    public class ConcreteBuilder : IBuilder
    {
        private IProduct product;

        public IProduct Create(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("name");
            ProductConfigurationElement config = ConfigurationBroker.GetConfiguration(name);
            if (config == null) return null;
            product = config.Create();
            // 通过Setter注入的方式，按照配置将产品类型实例的内容填充完整
            product.Name = config.Name;
            product.Price = config.Price;
            if ((config.Features == null) || (config.Features.Count == 0)) return product;
            foreach (FeatureConfigurationElement featureConfig in config.Features)
                BuildPart(featureConfig);  // 具体创建步骤
            return product;
        }

        public void BuildPart(FeatureConfigurationElement config)
        {
            if((product == null) || (product.Features == null)) return;
            IFeature feature = ConfigurationBroker.CreateFeature();
            feature.Name = config.Name;
            feature.Description = config.Description;
            product.Features.Add(feature);
        }
    }
}
