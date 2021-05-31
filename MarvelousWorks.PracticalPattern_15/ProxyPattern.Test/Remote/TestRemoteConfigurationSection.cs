using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.ProxyPattern.Remote.Common;
namespace ProxyPattern.Test.Remote
{
    [TestClass]
    public class TestRemoteConfigurationSection
    {
        [TestMethod]
        public void TestConfiguration()
        {
            RemoteConfigurationSection<string> config = new RemoteConfigurationSection<string>();
            IList<IProcess<string>> list = config.Handlers;
            Assert.AreEqual<int>(3, list.Count);
        }
    }
}
