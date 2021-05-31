using System;
namespace MarvellousWorks.PracticalPattern.FactoryMethod.Example1
{
    public interface IProduct { }
    public class ConcreteProductA : IProduct { }
    public class ConcreteProductB : IProduct { }

    public class Factory
    {
        public IProduct Create()
        {
            // ������������ʵ�����ĸ����ࡣ
            return new ConcreteProductA();
        }
    }
}
