using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.Idiom.Registry;
namespace MarvellousWorks.PracticalPattern.Idiom.Test.Registry
{
    [TestClass]
    public class TestRegistry
    {
        [TestMethod]
        public void TestSimpleRegistry()
        {
            string spName = "GetUserInfo";  // 存储过程名称
            DbParameterRegistry registry = new DbParameterRegistry(spName);
            registry["@ID"] = DbType.Int32;
            registry["@Title"] = DbType.String;
            Assert.IsTrue(registry.ContainsKey("@ID"));
            Assert.IsFalse(registry.ContainsKey("@Unknown"));
            Assert.AreEqual<DbType>(DbType.String, registry["@Title"]);
        }

        /// <summary>
        /// 保存数据参数注册表的注册表
        /// </summary>
        internal static class DbParameterRegistries
        {
            internal static IDictionary<string, DbParameterRegistry> registries =
                new Dictionary<string, DbParameterRegistry>();

            /// <summary>
            /// 生成全局注册表对象Key的算法
            /// </summary>
            /// <param name="command"></param>
            /// <returns></returns>
            private static string CreateRegistryKey(DbCommand command)
            {
                if (command == null) throw new ArgumentNullException("command");
                if (command.Connection == null) throw new ArgumentNullException("command.Connection");
                return command.Connection.ConnectionString + command.CommandText;
            }

            private static DbParameterRegistry DiscoverDbParameters(DbCommand command)
            {
                // 访问数据库并获得command指定存储的相关DbParameter[]的类型信息

                // 更新参数注册表
                string key = CreateRegistryKey(command);
                DbParameterRegistry registry = new DbParameterRegistry(key);
                foreach (DbParameter parameter in command.Parameters)
                    registry[parameter.ParameterName] = parameter.DbType;
                registries.Add(key, registry);
                return registry;
            }

            /// <summary>
            /// 获取存储过程DbCommand的参数类型信息
            /// 如果相应的注册表没有预先登记，则访问数据库执行参数发现过程
            /// </summary>
            /// <param name="command"></param>
            /// <returns></returns>
            internal static IEnumerable<DbType> GetDbParameterTypes(DbCommand command)
            {
                string key = CreateRegistryKey(command);
                DbParameterRegistry registry;
                if (!registries.TryGetValue(key, out registry))
                    registry = DiscoverDbParameters(command);
                return registry.Types;
            }
        }

        [TestMethod]
        public void TestRegistries()
        {
            DbCommand command = null;
            // 生成对应的command信息, 
            IEnumerable<DbType> types = DbParameterRegistries.GetDbParameterTypes(command);
            // 执行后续参数赋值、提交更新语句等操作
        }

        internal static IDictionary<string, IDictionary<string, DbType>> registries;
    }
}
