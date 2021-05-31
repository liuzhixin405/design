using System;
using MarvellousWorks.PracticalPattern.AdapterPattern.Classic;
namespace MarvellousWorks.PracticalPattern.AdapterPattern.Classic.ClassicObject
{
    public class Adapter : ITarget
    {
        private Adaptee adaptee;    // Adaptee����

        public void Request()
        {
            // ��������
            adaptee.SpecifiedRequest();    // ����Adaptee
        }
    }
}
