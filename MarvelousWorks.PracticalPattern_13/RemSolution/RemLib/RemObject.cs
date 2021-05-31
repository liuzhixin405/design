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
        /// 通过访问配置找到服务于具体数据库Provider的抽象工厂；
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
        /// 封装数据访问“子系统”的内部对象
        /// 通过协同DbConnection、DbCommand、DbDataAdapter和DataSet对外提供简单的查询接口；
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
