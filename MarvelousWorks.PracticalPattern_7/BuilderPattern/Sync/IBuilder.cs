using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.BuilderPattern.Sync
{
    public interface IBuilder
    {
        Car BuildUp();
    }

    public abstract class BuilderBase : IBuilder
    {
        protected IList<BuildStepHandler> steps = new List<BuildStepHandler>();
        protected Car car = new Car();

        public virtual Car BuildUp()
        {
            foreach (BuildStepHandler step in steps)
                step();
            return car;
        }
    }

    public class ConcreteBuilder : BuilderBase
    {
        /// <summary>
        /// 由于BuildStepHandler进描述抽象的BuildPart()方法，因此实际项目中，
        /// ConcreteBuilder需要配置的委托可以统一通过访问配置文件的方式获取。
        /// </summary>
        public ConcreteBuilder() : base()
        {
            steps.Add(car.AddEngine);
            steps.Add(car.AddWheel);
            steps.Add(car.AddBody);
        }
    }
}
