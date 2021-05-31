using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.SingletonPattern.Threading;
namespace SingletonPattern.Test.Threading
{
    /// <summary>
    /// 每个线程需要执行的目标对象定义
    /// 同时在它内部完成线程内部是否Singleton的情况
    /// </summary>
    class Work
    {
        public static IList<int> Log = new List<int>();

        /// <summary>
        /// 每个线程的执行部分定义
        /// </summary>
        public void Procedure()
        {
            Singleton s1 = Singleton.Instance;
            Singleton s2 = Singleton.Instance;

            // 证明可以正常构造实例
            Assert.IsNotNull(s1);
            Assert.IsNotNull(s2);

            // 验证当前线程执行体内部两次引用的是否为同一个实例
            Assert.AreEqual<int>(s1.GetHashCode(), s2.GetHashCode());
            //登记当前线程所使用的Singleton对象标识
            Log.Add(s1.GetHashCode());
        }
    }

    [TestClass]
    public class TestSingleton
    {
        private const int ThreadCount = 3;

        [TestMethod]
        public void Test()
        {
            // 创建一定数量的线程执行体
            Thread[] threads = new Thread[ThreadCount];
            for (int i = 0; i < ThreadCount; i++)
            {
                ThreadStart work = new ThreadStart((new Work()).Procedure);
                threads[i] = new Thread(work);
            }
            
            // 执行线程
            foreach (Thread thread in threads) thread.Start();

            // 终止线程并作其他清理工作
            // ... ...

            // 判断是否不同线程内部的Singleton实例是不同的
            for (int i = 0; i < ThreadCount - 1; i++)
                for (int j = i + 1; j < ThreadCount; j++)
                    Assert.AreNotEqual<int>(Work.Log[i], Work.Log[j]);
        }
    }
}
