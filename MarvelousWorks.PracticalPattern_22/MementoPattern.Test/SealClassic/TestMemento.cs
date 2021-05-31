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
            // ����ԭ�����ճ�ʼ�����״̬
            originator.SaveCheckpoint();

            // ��ԭ�������в�������֤״̬���޸�
            originator.IncreaseY();
            originator.DecreaseX();

            // ȷ�ϱ���¼�Ļָ�����
            originator.Undo();
            Assert.AreEqual<int>(0, originator.Current.Y);
            Assert.AreEqual<int>(0, originator.Current.X);
        }
    }
}
