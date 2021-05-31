using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.SingletonPattern.Threading;
namespace SingletonPattern.Test.Threading
{
    /// <summary>
    /// ÿ���߳���Ҫִ�е�Ŀ�������
    /// ͬʱ�����ڲ�����߳��ڲ��Ƿ�Singleton�����
    /// </summary>
    class Work
    {
        public static IList<int> Log = new List<int>();

        /// <summary>
        /// ÿ���̵߳�ִ�в��ֶ���
        /// </summary>
        public void Procedure()
        {
            Singleton s1 = Singleton.Instance;
            Singleton s2 = Singleton.Instance;

            // ֤��������������ʵ��
            Assert.IsNotNull(s1);
            Assert.IsNotNull(s2);

            // ��֤��ǰ�߳�ִ�����ڲ��������õ��Ƿ�Ϊͬһ��ʵ��
            Assert.AreEqual<int>(s1.GetHashCode(), s2.GetHashCode());
            //�Ǽǵ�ǰ�߳���ʹ�õ�Singleton�����ʶ
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
            // ����һ���������߳�ִ����
            Thread[] threads = new Thread[ThreadCount];
            for (int i = 0; i < ThreadCount; i++)
            {
                ThreadStart work = new ThreadStart((new Work()).Procedure);
                threads[i] = new Thread(work);
            }
            
            // ִ���߳�
            foreach (Thread thread in threads) thread.Start();

            // ��ֹ�̲߳�������������
            // ... ...

            // �ж��Ƿ�ͬ�߳��ڲ���Singletonʵ���ǲ�ͬ��
            for (int i = 0; i < ThreadCount - 1; i++)
                for (int j = i + 1; j < ThreadCount; j++)
                    Assert.AreNotEqual<int>(Work.Log[i], Work.Log[j]);
        }
    }
}
