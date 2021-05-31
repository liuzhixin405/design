using System;
namespace MarvellousWorks.PracticalPattern.Concept.DependencyInjection.Example2
{
    interface ITimeProvider
    {
        DateTime CurrentDate { get;}
    }

    class SystemTimeProvider : ITimeProvider
    {
        public DateTime CurrentDate { get { return DateTime.Now; } }
    }

    public class Client
    {
        public int GetYear()
        {
            ITimeProvider timeProvier = new SystemTimeProvider();
            return timeProvier.CurrentDate.Year;
        }
    }
}
