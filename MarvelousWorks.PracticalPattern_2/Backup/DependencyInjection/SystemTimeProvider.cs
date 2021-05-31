using System;
namespace MarvellousWorks.PracticalPattern.Concept.DependencyInjection
{
    public class SystemTimeProvider : ITimeProvider
    {
        public DateTime CurrentDate { get { return DateTime.Now; } }
    }
}
