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
            // ����ԭ�����ճ�ʼ�����״̬
            IMemento<Position> m1 = originator.Memento;

            // ��ԭ�������в�������֤״̬���޸�
            originator.IncreaseY();
            originator.DecreaseX();
            Assert.AreEqual<int>(1, originator.Current.Y);
            Assert.AreEqual<int>(-1, originator.Current.X);

            // ȷ�ϱ���¼�Ļָ�����
            originator.Memento = m1;
            Assert.AreEqual<int>(0, originator.Current.Y);
            Assert.AreEqual<int>(0, originator.Current.X);
        }
    }
}
