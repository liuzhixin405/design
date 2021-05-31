using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.AdapterPattern.Dual
{
    public class OracleDatabase
    {
        public string GetDatabaseName() { return "oracle"; }
        public int Select() { return (new Random()).Next(); }
        public void Add(int data) { }
    }

    public class SqlServerDatabase
    {
        public string DbName { get { return "SQL Server"; } }
        public int Query() { return (new Random()).Next(); }
        public void Insert(int data) { }
    }
}
