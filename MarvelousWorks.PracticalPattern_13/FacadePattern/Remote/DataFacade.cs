using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.FacadePattern.Remote
{
    public class DataFacade : MarshalByRefObject, IDataFacade
    {
        private const string dbName = "AdventureWorks";
        private static DbProviderFactory factory;
        private static string connectionString;

        /// <summary>
        /// ͨ�����������ҵ������ھ������ݿ�Provider�ĳ��󹤳���
        /// </summary>
        static DataFacade()
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[dbName];
            factory = DbProviderFactories.GetFactory(settings.ProviderName);
            connectionString = settings.ConnectionString;
        }

        /// <summary>
        /// Helper method
        /// </summary>
        /// <returns></returns>
        private static DbConnection CreateConnection()
        {
            DbConnection connection = factory.CreateConnection();
            connection.ConnectionString = DataFacade.connectionString;
            return connection;
        }

        /// <summary>
        /// ��װ���ݷ��ʡ���ϵͳ�����ڲ�����
        /// ͨ��ЭͬDbConnection��DbCommand��DbDataAdapter��DataSet�����ṩ�򵥵Ĳ�ѯ�ӿڣ�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataSet ExecuteQuery(string sql)
        {
            if (string.IsNullOrEmpty(sql)) throw new ArgumentNullException("sql");
            using (DbConnection connection = CreateConnection())
            {
                DbCommand command = connection.CreateCommand();
                command.CommandText = sql;
                command.CommandType = CommandType.Text;
                DbDataAdapter adapter = factory.CreateDataAdapter();
                adapter.SelectCommand = command;
                DataSet result = new DataSet();
                adapter.Fill(result);
                return result;
            }
        }
    }
}
