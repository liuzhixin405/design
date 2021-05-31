using System;
using System.Collections.Generic;
using System.Data;
namespace MarvellousWorks.PracticalPattern.FacadePattern.FluentInterface
{
    public interface IDataFacade
    {
        DataSet ExecuteQuery(string sql);
        /// <summary>
        /// 具有Fluent特性的接口方法
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        IDataFacade AddNewCurrency(string code, string name);
    }
}
