using System;
using MarvellousWorks.PracticalPattern.AdapterPattern.Classic;
namespace MarvellousWorks.PracticalPattern.AdapterPattern.Classic.ClassicClass
{
    public class Adapter : Adaptee, ITarget
    {
        public void Request()
        {
            // ��������
            base.SpecifiedRequest();    // ����Adaptee
        }
    }
}
