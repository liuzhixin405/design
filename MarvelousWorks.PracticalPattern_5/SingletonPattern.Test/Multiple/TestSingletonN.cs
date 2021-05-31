using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.SingletonPattern.Multiple;
namespace SingletonPattern.Test.Multiple
{
    [TestClass]
    public class TestSingletonN
    {
        [TestMethod]
        public void Test()
        {
            SingletonN s1 = SingletonN.Instance;
            SingletonN s2 = SingletonN.Instance;
            SingletonN s3 = SingletonN.Instance;

            // 超出容量，所以不能获得实例引用
            Assert.IsNull(s3);  
            // 两个不同实例
            Assert.AreNotEqual<int>(s1.GetHashCode(), s2.GetHashCode());

            s1.DeActivate();
            s3 = SingletonN.Instance;
            Assert.IsNotNull(s3);   // 有了空间，所以可以获得引用

            s2.DeActivate();
            Assert.IsNotNull(s3);   // 有了空间，所以可以获得引用
            // s3虽然获得了新的引用，但其实是之前已经创建的某个现成的
            Assert.IsTrue((s3.GetHashCode() == s1.GetHashCode()) ||
                (s3.GetHashCode() == s2.GetHashCode()));
        }
    }
}
