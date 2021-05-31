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
        /// �߼����Ӵ�����
        /// </summary>
        private const string Name = "LocalSQL";
        /// <summary>
        /// ADO.NETĬ�Ϸ�����DataTable����
        /// </summary>
        private const string SystemTableNameRoot = "Table";
        /// <summary>
        /// ���Ӵ�
        /// </summary>
        private readonly static string connectionString;

        /// <summary>
        /// ͨ�����û�ȡ���Ӵ�
        /// </summary>
        static SqlDbHelper()
        {
            connectionString = ConfigurationManager.ConnectionStrings[Name].ConnectionString;
        }

        #region ExecuteDataSet
        /// <summary>
        /// ʵ��ִ�в�ѯ���ڲ�����
        /// </summary>
        /// <param name="command">Command����</param>
        /// <param name="tableNames">ÿ��DataTable���������</param>
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
        /// ����SQL��ѯ���
        /// </summary>
        /// <param name="commandText">SQL</param>
        /// <param name="tableNames">ÿ����ѯ���ص�DataTable����</param>
        /// <param name="parameters">����</param>
        /// <returns>��ѯ���</returns>
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
        /// ����SQL��ѯ���
        /// </summary>
        /// <param name="commandText">SQL</param>
        /// <returns>��ѯ���</returns>
        public static DataSet ExecuteDataSet(string commandText)
        {
            return ExecuteDataSet(commandText, null);
        }
        #endregion
    }
}
