using System;
using System.Collections.Generic;
using System.Data;
namespace MarvellousWorks.PracticalPattern.FacadePattern.Remote
{
    public interface IDataFacade
    {
        DataSet ExecuteQuery(string sql);
    }
}
