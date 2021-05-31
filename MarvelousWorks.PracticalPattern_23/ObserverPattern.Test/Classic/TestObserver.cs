using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.ObserverPattern.Classic;
namespace MarvellousWorks.PracticalPattern.ObserverPattern.Test.Classic
{
    [TestClass]
    public class TestObserver
    {
        /// <summary>
        /// ��֤Ŀ�����ͶԹ۲������͵�1:N֪ͨ
        /// </summary>
        [TestMethod]
        public void TestMulticst()
        {
            SubjectBase<int> subject = new SubjectA<int>();
            Observer<int> observer1 = new Observer<int>();
            observer1.State = 10;
            Observer<int> observer2 = new Observer<int>();
            observer2.State = 20;

            // Attach Observer
            subject += observer1;
            subject += observer2;

            // ȷ��֪ͨ����Ч��
            subject.Update(1);
            Assert.AreEqual<int>(1, observer1.State);
            Assert.AreEqual<int>(1, observer2.State);

            // ȷ�ϱ��֪ͨ�б�����Ч��
            subject -= observer1;
            subject.Update(5);
            Assert.AreNotEqual<int>(5, observer1.State);
            Assert.AreEqual<int>(5, observer2.State);
        }

        /// <summary>
        /// ��֤ͬһ���۲��߶������ͬʱ���۲족���Ŀ�����
        /// </summary>
        [TestMethod]
        public void TestMultiSubject()
        {
            SubjectBase<int> subjectA = new SubjectA<int>();
            SubjectBase<int> subjectB = new SubjectA<int>();
            Observer<int> observer = new Observer<int>();
            observer.State = 20;
            subjectA += observer;
            subjectB += observer;

            subjectA.Update(10);
            Assert.AreEqual<int>(10, observer.State);
            subjectB.Update(5);
            Assert.AreEqual<int>(5, observer.State);
        }
    }
}
