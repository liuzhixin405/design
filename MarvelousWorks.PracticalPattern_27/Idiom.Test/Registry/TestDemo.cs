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
            string spName = "GetUserInfo";  // �洢��������
            DbParameterRegistry registry = new DbParameterRegistry(spName);
            registry["@ID"] = DbType.Int32;
            registry["@Title"] = DbType.String;
            Assert.IsTrue(registry.ContainsKey("@ID"));
            Assert.IsFalse(registry.ContainsKey("@Unknown"));
            Assert.AreEqual<DbType>(DbType.String, registry["@Title"]);
        }

        /// <summary>
        /// �������ݲ���ע����ע���
        /// </summary>
        internal static class DbParameterRegistries
        {
            internal static IDictionary<string, DbParameterRegistry> registries =
                new Dictionary<string, DbParameterRegistry>();

            /// <summary>
            /// ����ȫ��ע������Key���㷨
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
                // �������ݿⲢ���commandָ���洢�����DbParameter[]��������Ϣ

                // ���²���ע���
                string key = CreateRegistryKey(command);
                DbParameterRegistry registry = new DbParameterRegistry(key);
                foreach (DbParameter parameter in command.Parameters)
                    registry[parameter.ParameterName] = parameter.DbType;
                registries.Add(key, registry);
                return registry;
            }

            /// <summary>
            /// ��ȡ�洢����DbCommand�Ĳ���������Ϣ
            /// �����Ӧ��ע���û��Ԥ�ȵǼǣ���������ݿ�ִ�в������ֹ���
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
            // ���ɶ�Ӧ��command��Ϣ, 
            IEnumerable<DbType> types = DbParameterRegistries.GetDbParameterTypes(command);
            // ִ�к���������ֵ���ύ�������Ȳ���
        }

        internal static IDictionary<string, IDictionary<string, DbType>> registries;
    }
}
