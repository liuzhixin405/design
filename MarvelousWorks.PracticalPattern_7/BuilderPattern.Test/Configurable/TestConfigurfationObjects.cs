using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.BuilderPattern.Configurable;
namespace MarvellousWorks.PracticalPattern.BuilderPattern.Test.Configurable
{
    [TestClass]   
    public class TestConfigurfationObjects
    {
        private const string groupName = "marvellousWorks.practicalPattern.builder";
        [TestMethod]
        public void Test()
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            BuilderConfigurationSectionGroup sectionGroup = 
                (BuilderConfigurationSectionGroup)configuration.GetSectionGroup(groupName);
            Assert.IsNotNull(sectionGroup);
            IFeature feature = sectionGroup.CustomProducts.ConcreteFeature.Create();
            Assert.IsNotNull(feature);
            string productTypeName = sectionGroup.CustomProducts.Products["car"].TypeName;
            IProduct product = (IProduct)Activator.CreateInstance(Type.GetType(productTypeName));
            Assert.IsNotNull(product);
            Assert.AreEqual<string>("4", sectionGroup.CustomProducts.Products["car"].Features[0].Description);
        }
    }
}
