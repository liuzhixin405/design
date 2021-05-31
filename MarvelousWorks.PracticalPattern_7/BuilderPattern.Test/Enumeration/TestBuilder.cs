using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.BuilderPattern.Enumeration;
namespace MarvellousWorks.PracticalPattern.BuilderPattern.Test.Enumeration
{
    [TestClass]
    public class TestBuilder
    {
        /// <summary>
        /// �����Ͱ�ķ�ʽ
        /// </summary>
        class NormalPhaseDirector : DirectorBase
        {
            public override IEnumerable<StudyHandler> PlanSchedule(IBuilder builder)
            {
                yield return new StudyHandler(builder.StudyA);
                yield return new StudyHandler(builder.StudyB);
                yield return new StudyHandler(builder.StudyC);
            }
        }

        /// <summary>
        /// ��ĩ�ķ�ʽ
        /// </summary>
        class FinalPhaseDirector : DirectorBase
        {
            public override IEnumerable<StudyHandler> PlanSchedule(IBuilder builder)
            {
                yield return new StudyHandler(builder.StudyB);
                yield return new StudyHandler(builder.StudyB);
                yield return new StudyHandler(builder.StudyA);
            }
        }

        public class ConcreteBuilder : IBuilder
        {
            public string StudyA() { return "A"; }
            public string StudyB() { return "B"; }
            public string StudyC() { return "C"; }
        }

        [TestMethod]
        public void Test()
        {
            IBuilder builder = new ConcreteBuilder();
            IDirector director = new FinalPhaseDirector();  // ��ĩ��״̬
            IList<string> schedule = director.Construct(builder);
            Assert.AreEqual<string>("B", schedule[0]);
            Assert.AreEqual<string>("B", schedule[1]);
            director = new NormalPhaseDirector();
            schedule = director.Construct(builder);         // ƽ��״̬
            Assert.AreEqual<string>("A", schedule[0]);
            Assert.AreEqual<string>("B", schedule[1]);

        }
    }
}
