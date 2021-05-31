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
        /// ����BuildStepHandler�����������BuildPart()���������ʵ����Ŀ�У�
        /// ConcreteBuilder��Ҫ���õ�ί�п���ͳһͨ�����������ļ��ķ�ʽ��ȡ��
        /// </summary>
        public ConcreteBuilder() : base()
        {
            steps.Add(car.AddEngine);
            steps.Add(car.AddWheel);
            steps.Add(car.AddBody);
        }
    }
}
