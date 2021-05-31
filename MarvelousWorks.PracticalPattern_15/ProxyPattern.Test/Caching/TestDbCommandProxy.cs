using System;
using System.Data;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.ProxyPattern.Caching;
namespace ProxyPattern.Test.Caching
{
    [TestClass]
    public class TestDbCommandProxy
    {
        //[TestMethod]
        //public void TestMaxCacheQueueLength()
        //{
        //    int maxCacheQueueLength = (new DbContext()).MaxCacheQueueLength;
        //    Assert.AreEqual<int>(3, maxCacheQueueLength);
        //}

        [TestMethod]
        public void Test()
        {
            IDbCommand command = new DbCommandProxy();
            command.CommandText = "SELECT COUNT(*) FROM Person.Address WHERE 1 = 0";
            Assert.AreEqual<int>(0, (int)command.ExecuteScalar());
            // 确认是否缓冲机制已经生效
            Assert.AreEqual<int>(1, ((DbCommandProxy)command).CacheCount);
            command.ExecuteScalar();
            // 确认在执行内容不发生变化的情况下，是否代理可以用到缓冲
            Assert.AreEqual<int>(1, ((DbCommandProxy)command).CacheCount);
            // 修正执行SQL
            command.CommandText = "SELECT COUNT(*) FROM Person.Address";
            int firstValue = (int)command.ExecuteScalar();
            // 检查修正执行 SQL 后的缓冲加载情况
            Assert.AreEqual<int>(2, ((DbCommandProxy)command).CacheCount);
            command.CommandText = "SELECT COUNT(*) FROM Person.Address WHERE 1 = 1";
            command.ExecuteScalar();
            // 确认数据缓冲代理的自动更新机制
            Assert.AreEqual<int>(2, ((DbCommandProxy)command).CacheCount);
        }
    }
}
