using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.ShowCase.Raw
{
    public static class SqlDbHelper
    {
        /// <summary>
        /// 逻辑连接串名称
        /// </summary>
        private const string Name = "LocalSQL";
        /// <summary>
        /// ADO.NET默认反馈的DataTable名称
        /// </summary>
        private const string SystemTableNameRoot = "Table";
        /// <summary>
        /// 连接串
        /// </summary>
        private readonly static string connectionString;

        /// <summary>
        /// 通过配置获取连接串
        /// </summary>
        static SqlDbHelper()
        {
            connectionString = ConfigurationManager.ConnectionStrings[Name].ConnectionString;
        }

        #region ExecuteDataSet
        /// <summary>
        /// 实际执行查询的内部方法
        /// </summary>
        /// <param name="command">Command对象</param>
        /// <param name="tableNames">每个DataTable结果的名称</param>
		private static DataSet DoExecuteDataSet(SqlCommand command, string[] tableNames)
		{
            if(command == null) throw new ArgumentNullException("command");
            if(command.Connection == null) 
                throw new ArgumentNullException("command.Connection");

            using(SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                if(tableNames != null)
                    for (int i = 0; i < tableNames.Length; i++)
                    {
                        string systemTableName = (i == 0) ? 
                        SystemTableNameRoot : SystemTableNameRoot + i;
                        adapter.TableMappings.Add(systemTableName, tableNames[i]);
                    }
                DataSet result = new DataSet();
                adapter.Fill(result);
                return result;
            }
        }

        /// <summary>
        /// 返回SQL查询结果
        /// </summary>
        /// <param name="commandText">SQL</param>
        /// <param name="tableNames">每个查询返回的DataTable名称</param>
        /// <param name="parameters">参数</param>
        /// <returns>查询结果</returns>
        public static DataSet ExecuteDataSet(string commandText, string[] tableNames, 
            params SqlParameter[] parameters)
        {
            if (string.IsNullOrEmpty(commandText)) 
                throw new ArgumentNullException("commandText");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = commandText;
                if ((parameters != null) && (parameters.Length > 0))
                    foreach (SqlParameter parameter in parameters)
                        command.Parameters.Add(parameter);
                return DoExecuteDataSet(command, tableNames);
            }
        }

        /// <summary>
        /// 返回SQL查询结果
        /// </summary>
        /// <param name="commandText">SQL</param>
        /// <returns>查询结果</returns>
        public static DataSet ExecuteDataSet(string commandText)
        {
            return ExecuteDataSet(commandText, null);
        }
        #endregion
    }
}
