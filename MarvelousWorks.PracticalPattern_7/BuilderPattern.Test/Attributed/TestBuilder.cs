using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.BuilderPattern.Attributed;
namespace MarvellousWorks.PracticalPattern.BuilderPattern.Test.Attributed
{
    [TestClass]
    public class TestBuilder
    {
        public class Car
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
            Builder<Car> builder = new Builder<Car>();
            Car car = builder.BuildUp();
            Assert.IsNotNull(car);
            Assert.AreEqual<int>(2 + 1, car.Log.Count); // 实际只执行了两个方法, 但3次调用
            Assert.AreEqual<string>("body", car.Log[0]);    // 按照标注的次序执行
            Assert.AreEqual<string>("wheel", car.Log[2]);    // 按照标注的次序执行
        }
    }
}
