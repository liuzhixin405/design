using System;
using System.Collections.Generic;
using System.Data;
namespace MarvellousWorks.PracticalPattern.FacadePattern.FluentInterface
{
    public interface IDataFacade
    {
        DataSet ExecuteQuery(string sql);
        /// <summary>
        /// ����Fluent���ԵĽӿڷ���
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        IDataFacade AddNewCurrency(string code, string name);
    }
}
