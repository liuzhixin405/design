using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.AdapterPattern.Dual
{
    public interface IDatabaseAdapter
    {
        string ProviderName { get;}
        int GetData();
        void SetData(int data);
    }

    public class OracleAdapter : IDatabaseAdapter
    {
        private OracleDatabase adaptee = new OracleDatabase(); // 
        public string ProviderName { get { return adaptee.GetDatabaseName(); } }
        public int GetData() { return adaptee.Select(); }
        public void SetData(int data) { adaptee.Add(data); }
    }

    public class SqlServerAdapter : IDatabaseAdapter
    {
        private SqlServerDatabase adaptee = new SqlServerDatabase();
        public string ProviderName { get { return adaptee.DbName; } }
        public int GetData() { return adaptee.Query(); }
        public void SetData(int data) { adaptee.Insert(data); }
    }
}
