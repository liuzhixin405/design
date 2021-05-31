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
        /// 按部就班的方式
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
        /// 期末的方式
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
            IDirector director = new FinalPhaseDirector();  // 期末的状态
            IList<string> schedule = director.Construct(builder);
            Assert.AreEqual<string>("B", schedule[0]);
            Assert.AreEqual<string>("B", schedule[1]);
            director = new NormalPhaseDirector();
            schedule = director.Construct(builder);         // 平常状态
            Assert.AreEqual<string>("A", schedule[0]);
            Assert.AreEqual<string>("B", schedule[1]);

        }
    }
}
