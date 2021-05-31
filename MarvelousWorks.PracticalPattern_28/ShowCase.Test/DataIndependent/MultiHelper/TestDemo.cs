using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.ShowCase.DataIndependent.MultiHelper;
using MarvellousWorks.PracticalPattern.ShowCase;
namespace MarvellousWorks.PracticalPattern.ShowCase.Test.DataIndependent.MultiHelper
{
    [TestClass]
    public class TestDemo
    {
        [TestMethod]
        public void Test()
        {
            DataSet result = DbHelper.ExecuteDataSet("LocalSQL", "SELECT * FROM Shippers");
            DbTraceHelper.TraceData(result);
        }
    }
}
