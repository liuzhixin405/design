using System;
namespace MarvellousWorks.PracticalPattern.AdapterPattern.Grouping
{
    /// <summary>
    /// Adaptee 
    /// </summary>
    public class OracleDatabase
    {
        /// <summary>
        /// specified request
        /// </summary>
        public string GetDatabaseName() { return "oracle"; }
    }

    /// <summary>
    /// Adaptee 
    /// </summary>
    public class SqlServerDatabase
    {
        /// <summary>
        /// specified request
        /// </summary>
        public string DbName { get { return "SQL Server"; } }
    }
}

