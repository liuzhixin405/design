using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Configuration;
using System.Threading;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace MarvellousWorks.PracticalPattern.CommandPattern.Test.Async.Db
{
    [TestClass]
    public class TestCommand
    {
        private string ConnectionString
        {
            get
            {
                ConnectionStringSettings setting = 
                    ConfigurationManager.ConnectionStrings["Northwind"];
                return setting.ConnectionString;
            }
        }

        [TestMethod]
        public void Test()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                // 一个模拟的长时间调用
                string commandText = "WAITFOR DELAY '0:0:03';";
                commandText += "UPDATE Products SET ProductName = ProductName;";
                SqlCommand command = new SqlCommand(commandText, connection);
                connection.Open();

                // 定义异步回调机制
                AsyncCallback callback = new AsyncCallback(
                    delegate(IAsyncResult result)
                    {
                        SqlCommand localCommand = (SqlCommand)(result.AsyncState);
                        int rows = localCommand.EndExecuteNonQuery(result);
                        Assert.IsTrue(rows > 0);
                    });
                command.BeginExecuteNonQuery(callback, command);
                Thread.Sleep(5000);
            }
        }
    }
}
