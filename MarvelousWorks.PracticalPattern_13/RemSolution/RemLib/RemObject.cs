#region using
using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using Test.Rem.Common;
#endregion
namespace Test.Rem.Lib
{
    public class DataFacade : System.MarshalByRefObject, IDataFacade
	{
        private const string dbName = "AdventureWorks";
        private DbProviderFactory factory;
        private string connectionString;

        /// <summary>
        /// ͨ�����������ҵ������ھ������ݿ�Provider�ĳ��󹤳���
        /// </summary>
        public DataFacade()
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[dbName];
            factory = DbProviderFactories.GetFactory(settings.ProviderName);
            connectionString = settings.ConnectionString;
        }

        /// <summary>
        /// Helper method
        /// </summary>
        /// <returns></returns>
        private DbConnection CreateConnection()
        {
            DbConnection connection = factory.CreateConnection();
            connection.ConnectionString = this.connectionString;
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
            Console.WriteLine(sql);
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
                Console.WriteLine("Get Rows : " + result.Tables[0].Rows.Count.ToString());
                return result;
            }
        }

	}
}
