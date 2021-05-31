using System;
using MarvellousWorks.PracticalPattern.Concept.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace MarvellousWorks.PracticalPattern.Concept.DependencyInjection.Test.WrongAttributer
{
    class SystemTimeAttribute : Attribute, ITimeProvider
    {
        // ITimeProvider Members
        public DateTime CurrentDate
        {
            get { return DateTime.Now; }
        }
    }

    /// <summary>
    /// 通过Attributer实现注入
    /// </summary>
    [SystemTime]
    class Client
    {
    }
}
