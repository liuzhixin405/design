using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.SingletonPattern.Generic;
namespace SingletonPattern.Test.Generic
{
    /// <summary>
    /// 利用现有基础可以快速的构造出一批具有public static T Instance
    /// 类型特征的准Singleton类型，从整体上统一Singleton方式访问的入口。
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
            /// 使用传统Singleton方式访问，一样可以保证唯一性
            SingletonA sa1 = SingletonA.Instance;
            SingletonA sa2 = SingletonA.Instance;
            Assert.AreEqual<int>(sa1.GetHashCode(), sa2.GetHashCode());

            /// 也可以绕过Instance静态属性，直接实例化那些准Singleton类型
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
