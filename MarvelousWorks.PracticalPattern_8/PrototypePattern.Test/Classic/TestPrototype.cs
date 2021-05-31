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
            Assert.AreEqual<string>("A", image.Name); // 副本与样本当时的内容一致
            Assert.AreEqual<Type>(typeof(ConcretePrototype), image.GetType()); //具体类型
            image.Name = "B";   // 独立修改副本的内容
            Assert.IsTrue(sample.Name != image.Name);  // 证明是两个独立的个体
        }

        [TestMethod]
        public void TestReferenceType()
        {
            IPrototype image = sample.Clone();
            Assert.AreEqual<int>(image.Signal.GetHashCode(), sample.Signal.GetHashCode());
        }
    }
}
