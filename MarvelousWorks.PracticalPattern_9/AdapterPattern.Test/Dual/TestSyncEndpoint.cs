using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.AdapterPattern.Dual;
namespace MarvellousWorks.PracticalPattern.AdapterPattern.Test.Dual.Sync
{
    class Endpoint
    {
        private IList<IDatabaseAdapter> adapters = new List<IDatabaseAdapter>();
        public Endpoint()
        {
            DatabaseAdapterFactory factory = new DatabaseAdapterFactory();
            adapters.Add(factory.Create("sqlserver"));
            adapters.Add(factory.Create("oracle"));
            
            // ���캯������ִ������Adapter�Ĺ��졢׼���������������
        }

        public IDatabaseAdapter this[int index] { get { return adapters[index]; } }
    }

    [TestClass]
    public class TestSyncEndpoint
    {
        [TestMethod]
        public void Test()
        {
            Endpoint endPoint = new Endpoint();
            endPoint[0].SetData(endPoint[1].GetData());
        }
    }
}
