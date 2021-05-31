using System;
using System.Data.Common;
using System.Configuration;
namespace MarvellousWorks.PracticalPattern.AdapterPattern.Test.Configurable
{
    class Demo
    {
        public void Test()
        {
            ConnectionStringSettings setting = ConfigurationManager.ConnectionStrings["sales"];
            DbProviderFactory factory = DbProviderFactories.GetFactory(setting.ProviderName);
            DbConnection connection = factory.CreateConnection();
            connection.ConnectionString = setting.ConnectionString;
        }
    }
}
