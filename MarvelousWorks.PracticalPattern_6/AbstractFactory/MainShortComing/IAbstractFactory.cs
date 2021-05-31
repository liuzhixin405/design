using System;
namespace MarvellousWorks.PracticalPattern.AbstractFactory.MainShortComing
{
    /// <summary>
    /// 定义抽象工厂
    /// </summary>
    public interface IAbstractFactory
    {
        IProductA CreateProducctA();
        IProductB CreateProducctB();
        IProductC CreateProducctC();    // 新增
    }

    /// <summary>
    /// 实体工厂
    /// </summary>
    public class ConcreteFactory1 : IAbstractFactory
    {
        /// <summary>
        /// IAbstractFactory Members
        /// </summary>
        /// <returns></returns>
        public virtual IProductA CreateProducctA() { return new ProductA1(); }
        public virtual IProductB CreateProducctB() { return new ProductB1(); }
        public virtual IProductC CreateProducctC() { return new ProductC1(); }
    }
    public class ConcreteFactory2 : IAbstractFactory
    {
        /// <summary>
        /// IAbstractFactory Members
        /// </summary>
        /// <returns></returns>
        public virtual IProductA CreateProducctA() { return new ProductA2Y(); }
        public virtual IProductB CreateProducctB() { return new ProductB2(); }
        public virtual IProductC CreateProducctC() { return new ProductC2(); }
    }

}
