using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
namespace MarvellousWorks.PracticalPattern.ShowCase.DataIndependent.OO
{
    /// <summary>
    /// 定义模版
    /// 其中DbProviderFactory作为抽象工厂对象
    /// 负责提供Connection、Command、DataAdapter实例
    /// </summary>
    public abstract class Database
    {
        protected string name;
        protected string connectionString;
        protected DbProviderFactory factory;    // 抽象工厂对象

        private const string SystemTableNameRoot = "Table";

        /// <summary>
        /// 初始化过程获取配置信息
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
        /// 定义参数命名采用的前缀
        /// 具体前缀交给子类实现
        /// </summary>
        protected abstract string ParameterPrefix{get;}

        #region Events
        /// <summary>
        /// 数据库调用执行之前的事件
        /// </summary>
        public event EventHandler<DbEventArgs> BeforeExecution;

        /// <summary>
        /// 数据库调用执行之后的事件
        /// </summary>
        public event EventHandler<DbEventArgs> AfterExecution;
        #endregion

        /// <summary>
        /// 实际执行查询的内部方法
        /// </summary>
        /// <param name="command">命令对象</param>
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
                    BeforeExecution(this, args);    // 触发执行前的事件
                adapter.Fill(result);
                if (AfterExecution != null)
                    AfterExecution(this, args);     // 触发执行后的事件
                return result;
            }
        }

        /// <summary>
        /// 创建查询命令对象
        /// </summary>
        /// <param name="commandText">SQL</param>
        /// <param name="parameters">参数</param>
        /// <returns>命令对象</returns>
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
        /// 执行查询
        /// </summary>
        /// <param name="commandText">SQL</param>
        /// <param name="tableNames">每个查询返回的DataTable名称</param>
        /// <param name="parameters">参数</param>
        /// <returns>查询结果</returns>
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
        /// 执行查询
        /// </summary>
        /// <param name="commandText">SQL</param>
        /// <returns>查询结果</returns>
        public virtual DataSet ExecuteDataSet(string commandText)
        {
            return ExecuteDataSet(commandText, null);
        }
    }
}
