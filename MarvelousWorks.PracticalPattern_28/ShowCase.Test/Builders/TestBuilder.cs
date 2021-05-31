using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.ShowCase.Builders;
namespace MarvellousWorks.PracticalPattern.ShowCase.Test.Builders
{
    /// <summary>
    /// 把简写的数据驱动名称变成实际驱动名称的算法
    /// </summary>
    class ReplaceProviderStrategy : ConnectionStringStrategyBase
    {
        public override void Process(ref ConnectionStringSettings setting)
        {
            string providerName = setting.ProviderName;
            switch (setting.ProviderName)
            {
                case "SQL":
                    setting.ProviderName = "System.Data.SqlClient";
                    break;
                case "ORA":
                    setting.ProviderName = "System.Data.OracleClient";
                    break;
                default:
                    throw new NotSupportedException();
            }
        }
    }

    /// <summary>
    /// 把连接串中“Data Set”部分替换为实际可用的"Data Source"
    /// </summary>
    class ReplaceDataSourceStrategy : ConnectionStringStrategyBase
    {
        public override void Process(ref ConnectionStringSettings setting)
        {
            string connectionString = setting.ConnectionString;
            connectionString.Replace("Data Source", "Data Source");
            setting.ConnectionString = connectionString;
        }
    }

    [TestClass]
    public class TestBuilder
    {
        [TestMethod]
        public void Test()
        {
            Database db1 = DatabaseFactory.Create("Conn1");
            db1.ExecuteDataSet("SELECT * FROM Shippers");
            Database db2 = DatabaseFactory.Create("Conn2");
            db1.ExecuteDataSet("SELECT * FROM Shippers");
        }
    }
}
