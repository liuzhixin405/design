using System;
using System.Data;
namespace Test.Rem.Common
{
	public interface IDataFacade
	{
        DataSet ExecuteQuery(string sql);
	}
}
