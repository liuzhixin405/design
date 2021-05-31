using System;
namespace MarvellousWorks.PracticalPattern.AbstractFactory
{
    /// <summary>
    /// ������󹤳�
    /// </summary>
    public interface IAbstractFactory
    {
        IProductA CreateProducctA();
        IProductB CreateProducctB();
    }
}
