using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
namespace MarvellousWorks.PracticalPattern.FacadePattern.Dto
{
    public interface IDataFacade
    {
        DbDataReader ExecuteQuery(string sql);
    }
}
