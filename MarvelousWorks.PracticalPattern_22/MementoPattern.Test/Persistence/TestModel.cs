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
            // ��������������ԭ����ʵ�������Ƿֱ��޸�״̬
            Originator o1 = new Originator();
            o1.IncreaseY(); // x = 0; y = 1;
            o1.SaveCheckpoint(1);
            o1.IncreaseY(); // x = 0; y = 2
            o1.SaveCheckpoint(2);
            Originator o2 = new Originator();
            o2.UpdateX(3);  // x = 3; y = 0
            o2.SaveCheckpoint(2);

            // ��֤ԭ�������Ϳ��Խ����ⲿ�־û��Ʊ�����
            // ���������Ҳ�ͬʵ�����Զ���ʹ�ó־û���
            o1.Undo(1);
            Assert.AreEqual<int>(0, o1.Current.X);
            Assert.AreEqual<int>(1, o1.Current.Y);
            o2.Undo(2);
            Assert.AreEqual<int>(3, o2.Current.X);
            Assert.AreEqual<int>(0, o2.Current.Y);
        }
    }
}
