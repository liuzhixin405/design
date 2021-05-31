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
        /// 验证目标类型对观察者类型的1:N通知
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

            // 确认通知的有效性
            subject.Update(1);
            Assert.AreEqual<int>(1, observer1.State);
            Assert.AreEqual<int>(1, observer2.State);

            // 确认变更通知列表后的有效性
            subject -= observer1;
            subject.Update(5);
            Assert.AreNotEqual<int>(5, observer1.State);
            Assert.AreEqual<int>(5, observer2.State);
        }

        /// <summary>
        /// 验证同一个观察者对象可以同时“观察”多个目标对象
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
