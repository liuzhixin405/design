using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
namespace MarvellousWorks.PracticalPattern.ShowCase.DataIndependent.OO
{
    /// <summary>
    /// ����ģ��
    /// ����DbProviderFactory��Ϊ���󹤳�����
    /// �����ṩConnection��Command��DataAdapterʵ��
    /// </summary>
    public abstract class Database
    {
        protected string name;
        protected string connectionString;
        protected DbProviderFactory factory;    // ���󹤳�����

        private const string SystemTableNameRoot = "Table";

        /// <summary>
        /// ��ʼ�����̻�ȡ������Ϣ
        /// </summary>
        /// <param name="name"></param>
        public Database(string name)
        {
            if(string.IsNullOrEmpty(name)) throw new ArgumentNullException("name");
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[name];
            factory = DbProviderFactories.GetFactory(settings.ProviderName);
            connectionString = settings.ConnectionString;
            this.name = name;
        }

        /// <summary>
        /// ��������������õ�ǰ׺
        /// ����ǰ׺��������ʵ��
        /// </summary>
        protected abstract string ParameterPrefix{get;}

        #region Events
        /// <summary>
        /// ���ݿ����ִ��֮ǰ���¼�
        /// </summary>
        public event EventHandler<DbEventArgs> BeforeExecution;

        /// <summary>
        /// ���ݿ����ִ��֮����¼�
        /// </summary>
        public event EventHandler<DbEventArgs> AfterExecution;
        #endregion

        /// <summary>
        /// ʵ��ִ�в�ѯ���ڲ�����
        /// </summary>
        /// <param name="command">�������</param>
        /// <param name="tableNames"></param>
        /// <returns></returns>
        private DataSet DoExecuteDataSet(DbCommand command, string[] tableNames)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (command.Connection == null)
                throw new ArgumentNullException("command.Connection");

            using (DbDataAdapter adapter = factory.CreateDataAdapter())
            {
                adapter.SelectCommand = command;
                if (tableNames != null)
                {
                    for (int i = 0; i < tableNames.Length; i++)
                    {
                        string systemTableName = (i == 0) ?
                        SystemTableNameRoot : SystemTableNameRoot + i;
                        adapter.TableMappings.Add(systemTableName, tableNames[i]);
                    }
                }

                DataSet result = new DataSet();

                DbEventArgs args = new DbEventArgs();
                args.Command = command;
                if (BeforeExecution != null)
                    BeforeExecution(this, args);    // ����ִ��ǰ���¼�
                adapter.Fill(result);
                if (AfterExecution != null)
                    AfterExecution(this, args);     // ����ִ�к���¼�
                return result;
            }
        }

        /// <summary>
        /// ������ѯ�������
        /// </summary>
        /// <param name="commandText">SQL</param>
        /// <param name="parameters">����</param>
        /// <returns>�������</returns>
        protected virtual DbCommand CreateCommand(string commandText, 
            params IDataParameter[] parameters)
        {
            DbCommand command = factory.CreateCommand();
            command.CommandText = commandText;
            command.CommandType = CommandType.Text;

            if ((parameters != null) && (parameters.Length > 0))
            {
                foreach (IDataParameter parameter in parameters)
                {
                    if (!parameter.ParameterName.StartsWith(ParameterPrefix))
                        parameter.ParameterName += ParameterPrefix;
                    command.Parameters.Add(parameter);
                }
            }
            return command;
        }

        /// <summary>
        /// ִ�в�ѯ
        /// </summary>
        /// <param name="commandText">SQL</param>
        /// <param name="tableNames">ÿ����ѯ���ص�DataTable����</param>
        /// <param name="parameters">����</param>
        /// <returns>��ѯ���</returns>
        public virtual DataSet ExecuteDataSet(string commandText, string[] tableNames,
            params IDataParameter[] parameters)
        {
            if (string.IsNullOrEmpty(commandText))
                throw new ArgumentNullException("commandText");

            using (DbConnection connection = factory.CreateConnection())
            {
                connection.ConnectionString = this.connectionString;
                DbCommand command = CreateCommand(commandText, parameters);
                command.Connection = connection;
                return DoExecuteDataSet(command, tableNames);
            }
        }

        /// <summary>
        /// ִ�в�ѯ
        /// </summary>
        /// <param name="commandText">SQL</param>
        /// <returns>��ѯ���</returns>
        public virtual DataSet ExecuteDataSet(string commandText)
        {
            return ExecuteDataSet(commandText, null);
        }
    }
}
