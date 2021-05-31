using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.Idiom.PartialClass.DiffInterfacre
{
    /// <summary>
    /// ��Ҫʵ�ֵ�һ��ӿ�
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
    /// �ֳ���������ʵ�ֵ����� C
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
