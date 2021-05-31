using System;
using System.Collections.Generic;
using System.Xml;
using System.Data;
using System.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using MarvellousWorks.PracticalPattern.FacadePattern.Dto;
namespace FacadePattern.Test.Dto
{
    [TestClass]
    public class TestDataFacade
    {
        [TestMethod]
        public void TestExecuteDbDataReaderWithoutDTO()
        {
            IDataFacade facade = new DataFacade();
            using (DbDataReader reader = facade.ExecuteQuery("SELECT TOP 10  CurrencyCode, Name FROM Sales.Currency"))
            {
                Assert.IsTrue(reader.HasRows);
                while (reader.Read())
                    Trace.WriteLine(Convert.ToString(reader[0]));
            }
        }

        [TestMethod]
        public void TestExecuteDbDataReaderWithDTO()
        {
            IDataFacade facade = new DataFacade();
            DataFacadeAssembler assembler = new DataFacadeAssembler();
            IXmlDataDto dto = new DataFacadeAssembler().CreateDto(facade);
            XmlDocument doc = 
                dto.GetCurrency("SELECT TOP 10  CurrencyCode, Name FROM Sales.Currency");
            Assert.IsNotNull(doc);
        }
    }
}
