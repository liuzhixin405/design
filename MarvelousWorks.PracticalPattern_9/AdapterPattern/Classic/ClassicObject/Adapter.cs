using System;
using MarvellousWorks.PracticalPattern.AdapterPattern.Classic;
namespace MarvellousWorks.PracticalPattern.AdapterPattern.Classic.ClassicObject
{
    public class Adapter : ITarget
    {
        private Adaptee adaptee;    // Adaptee对象

        public void Request()
        {
            // 其他操作
            adaptee.SpecifiedRequest();    // 调用Adaptee
        }
    }
}
