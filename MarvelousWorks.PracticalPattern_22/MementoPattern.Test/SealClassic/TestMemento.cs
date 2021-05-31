using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.MementoPattern.SealClassic;
namespace MarvellousWorks.PracticalPattern.MementoPattern.Test.SealClassic
{
    [TestClass]
    public class TestMemento
    {
        [TestMethod]
        public void Test()
        {
            Originator originator = new Originator();
            // 保存原发器刚初始化后的状态
            originator.SaveCheckpoint();

            // 对原发器进行操作，验证状态的修改
            originator.IncreaseY();
            originator.DecreaseX();

            // 确认备忘录的恢复作用
            originator.Undo();
            Assert.AreEqual<int>(0, originator.Current.Y);
            Assert.AreEqual<int>(0, originator.Current.X);
        }
    }
}
