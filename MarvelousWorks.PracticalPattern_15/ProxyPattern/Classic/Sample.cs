using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace MarvellousWorks.PracticalPattern.ProxyPattern.Classic
{
    /// <summary>
    /// 定义客户程序需要的抽象类型
    /// </summary>
    public interface ISubject
    {
        string Request();
    }

    /// <summary>
    /// 具体实现客户程序需要的类型
    /// </summary>
    public class RealSubject : ISubject
    {
        public string Request() { return "from real subject"; }

        /// <summary>
        /// 这里使用Singleton的目的是模拟一个复杂性
        /// 比如：客户程序并不知道如何使用远端的具体类型
        /// </summary>
        private static ISubject singleton = new RealSubject();
        private RealSubject() { }
        public static ISubject Singleton { get { return singleton; } }
    }

    /// <summary>
    /// 代理类型，他知道如何满足客户程序的要求，同时知道具体类型如何访问
    /// </summary>
    public class Proxy : ISubject
    {
        public string Request() { return RealSubject.Singleton.Request(); }
    }


    [TestClass]
    public class Client
    {
        [TestMethod]
        public void Test()
        {
            ISubject subject = new Proxy();
            Assert.AreEqual<string>("from real subject", subject.Request());
        }
    }
}
