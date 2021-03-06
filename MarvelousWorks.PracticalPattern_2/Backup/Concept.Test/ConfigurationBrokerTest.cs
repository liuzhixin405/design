using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.Concept.Configurating;
namespace MarvellousWorks.PracticalPattern.Concept.Test
{
    [TestClass()]
    public class ConfigurationBrokerTest
    {
        [TestMethod]
        public void Test()
        {
            DelegatingParagramConfigurationSection s1 = ConfigurationBroker.Delegating;
            Assert.IsTrue(s1.Pictures["EventHandler"].Colorized);
            Assert.AreEqual<string>(
                "1对n的通知", s1.Examples["MulticastNotify"].Description);

            GenericsParagramConfigurationSection s2 = ConfigurationBroker.Generics;
            Assert.AreEqual<int>(1, s2.Diagrams.Count);
        }
    }
}
