using MarvellousWorks.PracticalPattern.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace MarvellousWorks.PracticalPattern.Common.Test
{
    [TestClass()]
    public class ConfigurationBrokerTest
    {
        [TestMethod]
        public void Test()
        {
            IObjectBuilder builder = 
                ConfigurationBroker.GetConfigurationObject<IObjectBuilder>();
            Assert.IsNotNull(builder);
        }
    }
}
