using System;
namespace MarvellousWorks.PracticalPattern.AbstractFactory
{
    /// <summary>
    /// 定义抽象工厂
    /// </summary>
    public interface IAbstractFactory
    {
        IProductA CreateProducctA();
        IProductB CreateProducctB();
    }
}
