using System;
namespace MarvellousWorks.PracticalPattern.AdapterPattern.Grouping
{
    /// <summary>
    /// Target
    /// </summary>
    public interface IDatabaseAdapter
    {
        /// <summary>
        /// Request()
        /// </summary>
        string ProviderName { get;}
    }

    /// <summary>
    /// Concrete Adapter
    /// </summary>
    public class OracleAdapter : IDatabaseAdapter
    {
        private OracleDatabase adaptee = new OracleDatabase();
        public string ProviderName { get { return adaptee.GetDatabaseName(); } }
    }

    /// <summary>
    /// Concrete Adapter
    /// </summary>
    public class SqlServerAdapter : IDatabaseAdapter
    {
        private SqlServerDatabase adaptee = new SqlServerDatabase();
        public string ProviderName { get { return adaptee.DbName; } }
    }
}
