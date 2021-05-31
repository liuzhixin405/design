using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.ShowCase.DataIndependent.OO;
using MarvellousWorks.PracticalPattern.ShowCase;
namespace MarvellousWorks.PracticalPattern.ShowCase.Test.DataIndependent.OO
{
    [TestClass]
    public class TestDemo
    {
        [TestMethod]
        public void Test()
        {
            Database db = DatabaseFactory.Create("LocalSQL");
            DataSet dataset = db.ExecuteDataSet("SELECT * FROM Shippers");
            DbTraceHelper.TraceData(dataset);
        }

        private void ModifyCommandTimeout(object sender, DbEventArgs args)
        {
            DbCommand command = args.Command;
            command.CommandTimeout = 1000;
        }

        private void TraceExecutedCommand(object sender, DbEventArgs args)
        {
            DbCommand command = args.Command;
            Trace.WriteLine(command.CommandText);
            Trace.WriteLine(command.CommandTimeout);
        }

        [TestMethod]
        public void TestDbEvent()
        {
            Database db = DatabaseFactory.Create("LocalSQL");
            db.BeforeExecution += ModifyCommandTimeout;
            db.AfterExecution += TraceExecutedCommand;
            DataSet dataset = db.ExecuteDataSet("SELECT * FROM Shippers");
        }
    }
}
