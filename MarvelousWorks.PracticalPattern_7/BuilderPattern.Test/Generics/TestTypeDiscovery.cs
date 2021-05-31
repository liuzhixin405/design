using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.BuilderPattern.Generics;
namespace MarvellousWorks.PracticalPattern.BuilderPattern.Test.Generics
{
    [TestClass]
    public class TestTypeDiscovery
    {
        class Car
        {
            public IList<string> Log = new List<string>();

            [BuildStep(2)]
            public void AddWheel() { Log.Add("wheel"); }
            public void AddEngine() { Log.Add("engine"); }
            [BuildStep(1, 2)]
            public void AddBody() { Log.Add("body"); }
        }

        [TestMethod]
        public void Test()
        {
            IList<BuildStepAttribute> steps = TypeDiscovery.DiscoveryBuildSteps(typeof(Car));
            foreach (BuildStepAttribute step in steps)
                Trace.WriteLine(step.Sequence + "  " + step.Times);
        }
    }
}
