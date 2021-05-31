using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Data.Common;
using System.Configuration;
namespace MarvellousWorks.PracticalPattern.ProxyPattern.Caching
{
    /// <summary>
    /// 隔离有关连接数据库类型和具体建立连接等复杂性问题的扶助对象
    /// </summary>
    public class DbContext
    {
        private string providerName;
        private string connectionString;

        public DbContext() : this("default") { }
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
        #region Private Fields
        private DbContext context;
        private string commandText;
        #endregion

        #region Constructors
        public DbCommandProxy(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("name");
            this.context = new DbContext(name);
        }
        public DbCommandProxy() : this("default") { }
        #endregion

        private CacheQueue cache = new CacheQueue();
        /// <summary>
        /// 具有自动淘汰机制的缓存对象
        /// </summary>
        class CacheQueue
        {
            internal Dictionary<string, object> cache = new Dictionary<string, object>();
            int maxLength;
            public CacheQueue()
            {
                this.maxLength = Convert.ToInt32(ConfigurationManager.AppSettings["MaxCacheQueueLength"]);
                if (maxLength <= 0) throw new ArgumentException("Max Cache Lenght <= 0");
            }

            public void Add(string commandText, object value)
            {
                if (cache.ContainsKey(commandText)) return;
                if (cache.Count == maxLength)
                {
                    string firstKey = string.Empty ;
                    foreach (string currentKey in cache.Keys)
                    {
                        firstKey = currentKey;
                        break;
                    }
                    cache.Remove(firstKey);
                }
                cache.Add(commandText, value);
            }

            public bool TryGetValue(string commandText, ref object value)
            {
                if ((cache.Count == 0) || (!cache.ContainsKey(commandText))) return false;
                value = cache[commandText];
                return true;
            }
        }

        public object ExecuteScalar()
        {
            object value = null;
            if (cache.TryGetValue(this.commandText, ref value)) return value;
            using (DbConnection connection = context.CreateConnection())
            {
                connection.Open();
                DbCommand command = connection.CreateCommand();
                command.CommandText = this.commandText;
                command.CommandType = CommandType.Text;
                value = command.ExecuteScalar();
                cache.Add(this.commandText, value);
                return value;
            }
        }

        /// <summary>
        /// 用于外界访问当前缓冲情况
        /// </summary>
        public int CacheCount { get { return this.cache.cache.Count; } }

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
