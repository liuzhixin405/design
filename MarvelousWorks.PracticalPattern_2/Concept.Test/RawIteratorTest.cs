using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.Concept.Iterating;
namespace MarvellousWorks.PracticalPattern.Concept.Test
{
    [TestClass()]
    public class RawIteratorTest
    {
        private System.IO.DirectoryInfo info;

        [TestMethod]
        public void Test()
        {
            int count = 0;  // 测试 IEnumerator
            RawIterator iterator = new RawIterator();
            foreach (int item in iterator)
                Assert.AreEqual<int>(count++, item);

            count = 1;      // 测试具有参数控制的 IEnumerable
            foreach (int item in iterator.GetRange(1, 3))
                Assert.AreEqual<int>(count++, item);

            string[] data = new string[] { "hello", "world", "!" };
            count = 0;      // 测试手工 “捏” 出来的 IEnumerable
            foreach (string item in iterator.Greeting)
                Assert.AreEqual<string>(data[count++], item);
        }
    }
}


