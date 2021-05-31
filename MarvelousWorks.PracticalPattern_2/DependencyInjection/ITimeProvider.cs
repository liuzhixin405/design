using System;
namespace MarvellousWorks.PracticalPattern.Concept.DependencyInjection
{
    public interface ITimeProvider
    {
        DateTime CurrentDate { get;}
    }
}
