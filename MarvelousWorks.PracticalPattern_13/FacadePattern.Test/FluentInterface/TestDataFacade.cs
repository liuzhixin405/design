using System;
using System.Collections.Generic;
using System.Data;
using MarvellousWorks.PracticalPattern.FacadePattern.FluentInterface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace FacadePattern.Test.FluentInterface
{
    [TestClass]
    public class TestDataFacade
    {
        [TestMethod]
        public void Test()
        {
            IDataFacade facade = new DataFacade();
            DataSet result = facade.ExecuteQuery("SELECT * FROM Sales.Currency");
            int currentRows = result.Tables[0].Rows.Count;

            ///连续添加5条记录
            facade.AddNewCurrency("DW1", "Known1").
                AddNewCurrency("DW2", "Known2").
                AddNewCurrency("DW3", "Known3").
                AddNewCurrency("DW4", "Known4").
                AddNewCurrency("DW5", "Known5");
            result = facade.ExecuteQuery("SELECT * FROM Sales.Currency");
            Assert.AreEqual<int>(currentRows + 5, result.Tables[0].Rows.Count);
        }

        /// delete from Sales.Currency where currencycode like 'DW%'
        /// SELECT * FROM Sales.Currency where currencycode like 'DW%'
        /// INSERT INTO Sales.Currency( CurrencyCode, [Name]) VALUES ('DWA', 'Known')

    }
}
