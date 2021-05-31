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
            // ȷ���Ƿ񻺳�����Ѿ���Ч
            Assert.AreEqual<int>(1, ((DbCommandProxy)command).CacheCount);
            command.ExecuteScalar();
            // ȷ����ִ�����ݲ������仯������£��Ƿ��������õ�����
            Assert.AreEqual<int>(1, ((DbCommandProxy)command).CacheCount);
            // ����ִ��SQL
            command.CommandText = "SELECT COUNT(*) FROM Person.Address";
            int firstValue = (int)command.ExecuteScalar();
            // �������ִ�� SQL ��Ļ���������
            Assert.AreEqual<int>(2, ((DbCommandProxy)command).CacheCount);
            command.CommandText = "SELECT COUNT(*) FROM Person.Address WHERE 1 = 1";
            command.ExecuteScalar();
            // ȷ�����ݻ��������Զ����»���
            Assert.AreEqual<int>(2, ((DbCommandProxy)command).CacheCount);
        }
    }
}
