using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.ShowCase.Raw;
using MarvellousWorks.PracticalPattern.ShowCase;
namespace MarvellousWorks.PracticalPattern.ShowCase.Test.Raw
{
    [TestClass]
    public class TestDbHelper
    {
        [TestMethod]
        public void TestSQLReturnMultiDataTables()
        {
            string sql = "SELECT * FROM Region; SELECT * FROM Shippers";
            string[] tableName = new string[] { "Region", "Shipper" };
            DataSet result = SqlDbHelper.ExecuteDataSet(sql, tableName);
            DbTraceHelper.TraceData(result);
        }

        [TestMethod]
        public void TestParameterizedSQLReturnMultiDataTables()
        {
            string sql = "SELECT * FROM Region WHERE RegionID = @RegionID;";
            sql += "SELECT * FROM Shippers WHERE ShipperID = @ShipperID;";
            string[] tableName = new string[] { "Region", "Shipper" };
            SqlParameter regionID = new SqlParameter("@RegionID", 1);
            SqlParameter shipperID = new SqlParameter("@ShipperID", 2);
            DataSet result = SqlDbHelper.ExecuteDataSet(sql, tableName, regionID, shipperID);
            DbTraceHelper.TraceData(result);
        }

    }
}
