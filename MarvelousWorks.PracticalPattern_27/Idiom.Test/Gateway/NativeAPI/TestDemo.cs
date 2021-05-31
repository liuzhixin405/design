using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.Idiom.Gateway.NativeAPI;
namespace MarvellousWorks.PracticalPattern.Idiom.Test.Gateway.NativeAPI
{
    [TestClass]
    public class TestDemo
    {
        [TestMethod]
        public void TestInvokeAPI()
        {
            PerformanceCounterGateway gateway = new PerformanceCounterGateway();
            int counter = 0;
            gateway.Reset();
            for (int i = 0; i < 100; i++)
                for (int j = 0; j < 100; j++)
                    counter++;
            gateway.Stop();
            Trace.WriteLine(gateway.Frequency);
            Trace.WriteLine(gateway.ElapsedSeconds);
        }
    }
}