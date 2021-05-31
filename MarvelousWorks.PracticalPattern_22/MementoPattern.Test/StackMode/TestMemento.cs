using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.MementoPattern.StackMode;
namespace MarvellousWorks.PracticalPattern.MementoPattern.Test.StackMode
{
    [TestClass]
    public class TestMemento
    {
        [TestMethod]
        public void Test()
        {
            Originator originator = new Originator();
            // ����ԭ�����ճ�ʼ�����״̬
            originator.SaveCheckpoint();    // x = 0, y = 0

            // ��ԭ���������޸� 1
            originator.IncreaseY();
            originator.DecreaseX();
            originator.SaveCheckpoint();    // x = -1, y = 1

            // ��ԭ���������޸� 2
            originator.UpdateX(2);
            originator.SaveCheckpoint();    // x = 2, y = 1

            // ��ԭ���������޸� 3
            originator.UpdateX(3);
            originator.IncreaseY();         // x = 3, y = 2
            

            // ȷ��Undoǰ��״̬
            Assert.AreEqual<int>(3, originator.Current.X);
            Assert.AreEqual<int>(2, originator.Current.Y);
            

            // ȷ�ϱ���¼��ջʽ�ָ����á����ָ����޸�
            originator.Undo();
            Assert.AreEqual<int>(2, originator.Current.X);
            Assert.AreEqual<int>(1, originator.Current.Y);

            // ȷ�ϱ���¼��ջʽ�ָ����á����ָ����޸�1
            originator.Undo();
            Assert.AreEqual<int>(-1, originator.Current.X);
            Assert.AreEqual<int>(1, originator.Current.Y);
        }
    }
}
