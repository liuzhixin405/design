using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.MementoPattern.Classic;
namespace MarvellousWorks.PracticalPattern.MementoPattern.Test.Classic
{
    [TestClass]
    public class TestMemento
    {
        [TestMethod]
        public void Test()
        {
            Originator originator = new Originator();
            Assert.AreEqual<int>(0, originator.Current.Y);
            Assert.AreEqual<int>(0, originator.Current.X);
            // 保存原发器刚初始化后的状态
            IMemento<Position> m1 = originator.Memento;

            // 对原发器进行操作，验证状态的修改
            originator.IncreaseY();
            originator.DecreaseX();
            Assert.AreEqual<int>(1, originator.Current.Y);
            Assert.AreEqual<int>(-1, originator.Current.X);

            // 确认备忘录的恢复作用
            originator.Memento = m1;
            Assert.AreEqual<int>(0, originator.Current.Y);
            Assert.AreEqual<int>(0, originator.Current.X);
        }
    }
}
