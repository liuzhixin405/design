using System;
using System.Collections;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.BuilderPattern.Enumeration
{
    /// <summary>
    /// �����Ľ�������ί��������ĳ��󷽷�
    /// </summary>
    /// <returns></returns>
    public delegate string StudyHandler();

    public interface IBuilder
    {
        string StudyA();  // BuildPart()
        string StudyB();  // BuildPart()
        string StudyC();  // BuildPart()
    }

    public interface IDirector
    {
        IEnumerable<StudyHandler> PlanSchedule(IBuilder builder);
        IList<string> Construct(IBuilder builder);  // ����ѧϰ�ƻ�
    }

    public abstract class DirectorBase : IDirector
    {
        public abstract IEnumerable<StudyHandler> PlanSchedule(IBuilder builder);

        public IList<string> Construct(IBuilder builder)
        {
            IList<string> schedule = new List<string>();
            foreach (StudyHandler handler in PlanSchedule(builder))
                schedule.Add(handler());
            return schedule;
        }
    }
}
