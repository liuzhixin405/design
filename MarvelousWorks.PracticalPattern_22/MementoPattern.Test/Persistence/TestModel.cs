using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.MementoPattern.Persistence;
namespace MarvellousWorks.PracticalPattern.MementoPattern.Test.Persistence
{
    [TestClass]
    public class TestModel
    {
        [TestMethod]
        public void Main()
        {
            // 定义两个独立的原发器实例，他们分别修改状态
            Originator o1 = new Originator();
            o1.IncreaseY(); // x = 0; y = 1;
            o1.SaveCheckpoint(1);
            o1.IncreaseY(); // x = 0; y = 2
            o1.SaveCheckpoint(2);
            Originator o2 = new Originator();
            o2.UpdateX(3);  // x = 3; y = 0
            o2.SaveCheckpoint(2);

            // 验证原发器类型可以借助外部持久机制保存多分
            // 备案，而且不同实例可以独立使用持久机制
            o1.Undo(1);
            Assert.AreEqual<int>(0, o1.Current.X);
            Assert.AreEqual<int>(1, o1.Current.Y);
            o2.Undo(2);
            Assert.AreEqual<int>(3, o2.Current.X);
            Assert.AreEqual<int>(0, o2.Current.Y);
        }
    }
}
