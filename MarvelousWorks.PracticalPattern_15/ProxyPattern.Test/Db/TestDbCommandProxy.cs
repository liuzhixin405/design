using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.ProxyPattern.Db;
namespace ProxyPattern.Test.Db
{
    [TestClass]
    public class Client
    {
        [TestMethod]
        public void Test()
        {
            IDbCommand command = new DbCommandProxy();
            command.CommandText = "SELECT COUNT(*) FROM Person.Address WHERE 1 = 0";
            Assert.AreEqual<int>(0, (int)command.ExecuteScalar());
        }
    }
}
