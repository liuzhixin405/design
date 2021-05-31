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

            // �������������Բ��ܻ��ʵ������
            Assert.IsNull(s3);  
            // ������ͬʵ��
            Assert.AreNotEqual<int>(s1.GetHashCode(), s2.GetHashCode());

            s1.DeActivate();
            s3 = SingletonN.Instance;
            Assert.IsNotNull(s3);   // ���˿ռ䣬���Կ��Ի������

            s2.DeActivate();
            Assert.IsNotNull(s3);   // ���˿ռ䣬���Կ��Ի������
            // s3��Ȼ������µ����ã�����ʵ��֮ǰ�Ѿ�������ĳ���ֳɵ�
            Assert.IsTrue((s3.GetHashCode() == s1.GetHashCode()) ||
                (s3.GetHashCode() == s2.GetHashCode()));
        }
    }
}
