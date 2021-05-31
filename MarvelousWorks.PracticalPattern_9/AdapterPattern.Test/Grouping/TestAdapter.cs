using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.AdapterPattern.Grouping;
namespace MarvellousWorks.PracticalPattern.AdapterPattern.Test.Grouping
{
    [TestClass]
    public class TestAdapter
    {
        [TestMethod]
        public void Test()
        {
            DatabaseAdapterFactory factory = new DatabaseAdapterFactory();
            IDatabaseAdapter adapter = factory.Create("oracle");
            Assert.AreEqual<string>("oracle", adapter.ProviderName);
            Assert.AreEqual<Type>(typeof(OracleAdapter), adapter.GetType());
        }
    }
}
