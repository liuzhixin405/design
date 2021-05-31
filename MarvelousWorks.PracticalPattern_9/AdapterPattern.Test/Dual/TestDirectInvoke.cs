using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.AdapterPattern.Dual;
namespace MarvellousWorks.PracticalPattern.AdapterPattern.Test.Dual
{
    [TestClass]
    public class TestDirectInvoke
    {
        [TestMethod]
        public void Test()
        {
            DatabaseAdapterFactory factory = new DatabaseAdapterFactory();
            IDatabaseAdapter a = factory.Create("oracle");
            IDatabaseAdapter b = factory.Create("sqlserver");
            b.SetData(a.GetData());
        }
    }
}
