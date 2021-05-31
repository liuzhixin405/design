using System;
using System.Collections.Generic;
using System.Data;
using MarvellousWorks.PracticalPattern.FacadePattern.Classic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace FacadePattern.Test.Classic
{
    [TestClass]
    public class TestDataFacade
    {
        [TestMethod]
        public void Test()
        {
            DataFacade facade = new DataFacade();
            DataSet result = facade.ExecuteQuery("SELECT TOP 10 CurrencyCode, Name FROM Sales.Currency");
            Assert.AreEqual<int>(1, result.Tables.Count);
        }
    }
}
