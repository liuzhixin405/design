using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;
using System.Collections.Specialized;
namespace FactoryMethod.Test.Classic
{
    [TestClass]
    public class TestConfiguration
    {
        private const string SectionName = 
            "marvellousWorks.practicalPattern.factoryMethod.customFactories";

        [TestMethod]
        public void Test()
        {
            NameValueCollection collection =
                (NameValueCollection)ConfigurationSettings.GetConfig(SectionName);
            string typeName = collection["MarvellousWorks.PracticalPattern.FactoryMethod.Classic.IFactory, MarvellousWorks.PracticalPattern.FactoryMethod"];
            Type type = Type.GetType(typeName);
            Assert.IsNotNull(type);
        }
    }
}
