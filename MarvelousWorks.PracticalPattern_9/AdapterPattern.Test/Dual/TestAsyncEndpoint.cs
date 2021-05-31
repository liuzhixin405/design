using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.AdapterPattern.Dual;
namespace MarvellousWorks.PracticalPattern.AdapterPattern.Test.Dual.Async
{
    delegate void AfterInvokeHandler(int requestIndex, int responseIndex,
            string requestMethod, string responseMethod);
 
    class Endpoint
    {
        private IList<IDatabaseAdapter> adapters = new List<IDatabaseAdapter>();
        public Endpoint()
        {
            DatabaseAdapterFactory factory = new DatabaseAdapterFactory();
            adapters.Add(factory.Create("sqlserver"));
            adapters.Add(factory.Create("oracle"));
        }

        /// <summary>
        /// ͨ�����䣬ִ��һ�����������
        /// </summary>
        public void Invoke(int requestIndex, string requestMethod, int responseIndex,  
            string responseMethod, bool needRelay, AfterInvokeHandler callback)
        {
            object requester = adapters[requestIndex];
            object responser = adapters[responseIndex];
            MethodInfo request = requester.GetType().GetMethod(requestMethod);
            MethodInfo response = responser.GetType().GetMethod(responseMethod);
            object result = response.Invoke(responser, null);
            if (needRelay)
                request.Invoke(requester, new object[] { result });
            else
                request.Invoke(requester, null);

            // �첽�ص���ִ֪ͨ�����
            callback(responseIndex, responseIndex, requestMethod, responseMethod);
        }
    }

    [TestClass]
    public class TestAsyncEndpoint
    {
        [TestMethod]
        public void Test()
        {
            Endpoint endPoint = new Endpoint();
            // �൱�ڵ��� endPoint[0].SetData(endPoint[1].GetData());
            endPoint.Invoke(0, "SetData", 1, "GetData", true, Log);
        }

        private void Log(int requestIndex, int responseIndex,
            string requestMethod, string responseMethod) { }
    }
}
