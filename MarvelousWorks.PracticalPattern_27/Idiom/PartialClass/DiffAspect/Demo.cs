using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.Idiom.PartialClass.DiffAspect
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PerformanceAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Class)]
    public class PersistenceAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Class)]
    public class SecurityAttribute : Attribute { }


    [Performance]
    public partial class C { }

    [Persistence]
    public partial class C { }

    [Security]
    public partial class C { }
}
