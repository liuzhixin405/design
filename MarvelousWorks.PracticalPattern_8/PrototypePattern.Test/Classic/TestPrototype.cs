using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.PrototypePattern.Classic;
namespace MarvellousWorks.PracticalPattern.PrototypePattern.Test.Classic
{
    [TestClass]
    public class TestPrototype
    {
        private IPrototype sample = new ConcretePrototype();

        [TestMethod]
        public void Test()
        {    
            sample.Name = "A";
            IPrototype image = sample.Clone();
            Assert.AreEqual<string>("A", image.Name); // ������������ʱ������һ��
            Assert.AreEqual<Type>(typeof(ConcretePrototype), image.GetType()); //��������
            image.Name = "B";   // �����޸ĸ���������
            Assert.IsTrue(sample.Name != image.Name);  // ֤�������������ĸ���
        }

        [TestMethod]
        public void TestReferenceType()
        {
            IPrototype image = sample.Clone();
            Assert.AreEqual<int>(image.Signal.GetHashCode(), sample.Signal.GetHashCode());
        }
    }
}
