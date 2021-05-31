using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.SingletonPattern.Generic;
namespace SingletonPattern.Test.Generic
{
    /// <summary>
    /// �������л������Կ��ٵĹ����һ������public static T Instance
    /// ����������׼Singleton���ͣ���������ͳһSingleton��ʽ���ʵ���ڡ�
    /// </summary>
    class SingletonA : SingletonBase<SingletonA> { }
    class SingletonB : SingletonBase<SingletonB> { }
    class SingletonC : SingletonBase<SingletonC> { }

   
    [TestClass]
    public class TestSingleton
    {
        [TestMethod]
        public void Test()
        {
            /// ʹ�ô�ͳSingleton��ʽ���ʣ�һ�����Ա�֤Ψһ��
            SingletonA sa1 = SingletonA.Instance;
            SingletonA sa2 = SingletonA.Instance;
            Assert.AreEqual<int>(sa1.GetHashCode(), sa2.GetHashCode());

            /// Ҳ�����ƹ�Instance��̬���ԣ�ֱ��ʵ������Щ׼Singleton����
            SingletonA sa3 = new SingletonA();
            Assert.IsNotNull(sa3);
            Assert.AreNotEqual<int>(sa1.GetHashCode(), sa3.GetHashCode());
        }

        class SingletonFactory
        {
            public ISingleton Create() { return SingletonA.Instance; }
        }

        [TestMethod]
        public void TestSingletonFactory()
        {
            ISingleton singleton = (new SingletonFactory()).Create();
            Assert.IsNotNull(singleton);
        }
    }
}
