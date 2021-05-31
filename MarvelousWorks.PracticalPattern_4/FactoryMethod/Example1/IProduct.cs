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
            // 工厂决定到底实例化哪个子类。
            return new ConcreteProductA();
        }
    }
}
