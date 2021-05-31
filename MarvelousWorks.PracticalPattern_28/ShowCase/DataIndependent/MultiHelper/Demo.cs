using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Data.SqlClient;
namespace MarvellousWorks.PracticalPattern.ShowCase.DataIndependent.MultiHelper
{
    public static class DbHelper
    {
        /// <summary>
        /// 执行查询
        /// </summary>
        /// <param name="name">逻辑数据库名称</param>
        /// <param name="commandText">SQL</param>
        /// <param name="tableNames">反馈结果DataTable名称</param>
        /// <param name="parameters">参数</param>
        /// <returns>查询结果</returns>
        public static DataSet ExecuteDataSet(string name, string commandText, string[] tableNames,
            params IDataParameter[] parameters)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("name");
            if (string.IsNullOrEmpty(commandText)) throw new ArgumentNullException("commandText");
            string connectionString = ConfigurationManager.ConnectionStrings[name].ConnectionString;
            string providerName = ConfigurationManager.ConnectionStrings[name].ProviderName;

            switch (providerName)
            {
                case "System.Data.SqlClient":
                    return SqlDbHelper.ExecuteDataSet(connectionString, 
                        commandText, tableNames, parameters);
                case "System.Data.OracleClient":
                    return OracleDbHelper.ExecuteDataSet(connectionString, 
                        commandText, tableNames, parameters);
                default:
                    throw new NotSupportedException();
            }
        }

        /// <summary>
        /// 执行查询
        /// </summary>
        /// <param name="name"></param>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public static DataSet ExecuteDataSet(string name, string commandText)
        {
            return ExecuteDataSet(name, commandText, null);
        }
    }

    public static class SqlDbHelper
    {
        private const string SystemTableNameRoot = "Table";

        #region ExecuteDataSet
        private static DataSet DoExecuteDataSet(SqlCommand command, string[] tableNames)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (command.Connection == null)
                throw new ArgumentNullException("command.Connection");

            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                if (tableNames != null)
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

        public static DataSet ExecuteDataSet(string connectionString, string commandText, 
            string[] tableNames, params IDataParameter[] parameters)
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

        public static DataSet ExecuteDataSet(string connectionString, string commandText)
        {
            return ExecuteDataSet(connectionString, commandText, null);
        }
        #endregion
    }

    public static class OracleDbHelper
    {
        private const string SystemTableNameRoot = "Table";

        #region ExecuteDataSet
        private static DataSet DoExecuteDataSet(OracleCommand command, string[] tableNames)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (command.Connection == null)
                throw new ArgumentNullException("command.Connection");

            using (OracleDataAdapter adapter = new OracleDataAdapter(command))
            {
                if (tableNames != null)
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

        public static DataSet ExecuteDataSet(string connectionString, string commandText,
            string[] tableNames, params IDataParameter[] parameters)

        {
            if (string.IsNullOrEmpty(commandText))
                throw new ArgumentNullException("commandText");

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = commandText;
                if ((parameters != null) && (parameters.Length > 0))
                    foreach (OracleParameter parameter in parameters)
                        command.Parameters.Add(parameter);
                return DoExecuteDataSet(command, tableNames);
            }
        }

        public static DataSet ExecuteDataSet(string connectionString, string commandText)
        {
            return ExecuteDataSet(connectionString, commandText, null);
        }
        #endregion
    }

}
