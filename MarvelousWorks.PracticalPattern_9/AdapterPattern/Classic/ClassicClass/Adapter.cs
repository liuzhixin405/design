using System;
using MarvellousWorks.PracticalPattern.AdapterPattern.Classic;
namespace MarvellousWorks.PracticalPattern.AdapterPattern.Classic.ClassicClass
{
    public class Adapter : Adaptee, ITarget
    {
        public void Request()
        {
            // 其他操作
            base.SpecifiedRequest();    // 调用Adaptee
        }
    }
}
