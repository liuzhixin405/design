using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration;

namespace MarvellousWorks.PracticalPattern.ProxyPattern.Db
{
    /// <summary>
    /// 隔离有关连接数据库类型和具体建立连接等复杂性问题的扶助对象
    /// </summary>
    class DbContext
    {
        private string providerName;
        private string connectionString;

        public DbContext(string name)
        {
            ConnectionStringSettings setting = ConfigurationManager.ConnectionStrings[name];
            this.providerName = setting.ProviderName;
            this.connectionString = setting.ConnectionString;
        }

        public DbConnection CreateConnection()
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory(this.providerName);
            DbConnection connection = factory.CreateConnection();
            connection.ConnectionString = this.connectionString;
            return connection;
        }
    }       

    public class DbCommandProxy : IDbCommand
    {
        private DbContext context;
        private string commandText;

        public DbCommandProxy(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("name");
            this.context = new DbContext(name);
        }
        public DbCommandProxy() : this("default") { }

        public object ExecuteScalar()
        {
            using (DbConnection connection = context.CreateConnection())
            {
                connection.Open();
                DbCommand command = connection.CreateCommand();
                command.CommandText = this.commandText;
                command.CommandType = CommandType.Text;
                return command.ExecuteScalar();
            }
        }

        public string CommandText
        {
            get { return this.commandText; }
            set { this.commandText = value; }
        }

        #region NotImplemented

        public int ExecuteNonQuery()
        {
            throw new NotImplementedException();
        }

        public IDataReader ExecuteReader(CommandBehavior behavior)
        {
            throw new NotImplementedException();
        }

        public IDataReader ExecuteReader()
        {
            throw new NotImplementedException();
        }

        public void Cancel()
        {
            throw new NotImplementedException();
        }



        public int CommandTimeout
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public CommandType CommandType
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IDbConnection Connection
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IDbDataParameter CreateParameter()
        {
            throw new NotImplementedException();
        }



        public IDataParameterCollection Parameters
        {
            get { throw new NotImplementedException(); }
        }

        public void Prepare()
        {
            throw new NotImplementedException();
        }

        public IDbTransaction Transaction
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public UpdateRowSource UpdatedRowSource
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
