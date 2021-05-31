using System;
namespace MarvellousWorks.PracticalPattern.AdapterPattern.Classic
{
    public interface ITarget
    {
        void Request();
    }

    public class Adaptee
    {
        public void SpecifiedRequest() { }
    }
}
