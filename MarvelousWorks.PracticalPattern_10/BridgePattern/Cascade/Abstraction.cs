using System;
using System.Data;
using System.Xml;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.BridgePattern.Cascade
{
    public interface IDataConnection
    {
        void Open();
        DataSet Query(string sql);
    }

    public interface ISqlBuilder
    {
        string GetWhereClause(object data);
    }

    public interface IDataCommand
    {
        IDataConnection Connection { get; set;}
        ISqlBuilder Builder { get; set;}
        DataSet Execute(string databaseName, string tableName, object data);
    }

    public interface IDataFormatter
    {
        string Format(DataSet dataSet);
    }

    public interface IDataControl
    {
        IDataCommand Command { get; set;}
        IDataFormatter Formatter { get; set;}

        object Data { get;}
        string TableName { get; set;}
        string DatabaseName { get; set;}
        void Bind();
    }
}
