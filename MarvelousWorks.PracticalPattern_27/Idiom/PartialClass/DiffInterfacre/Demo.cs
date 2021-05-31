using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.Idiom.PartialClass.DiffInterfacre
{
    /// <summary>
    /// 需要实现的一组接口
    /// </summary>
    public interface IA 
    {
        void MethodA();
    }
    public interface IB
    {
        void MethodB();
    }

    public interface IC
    {
        void MethodC();
    }

    /// <summary>
    /// 分成三个部分实现的类型 C
    /// </summary>
    public partial class C : IA
    {
        public void MethodA() { }
    }

    public partial class C : IB
    {
        public void MethodB() { }
    }

    public partial class C : IC
    {
        public void MethodC() { }
    }
}
