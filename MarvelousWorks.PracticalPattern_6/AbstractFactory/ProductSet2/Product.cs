using System;
namespace MarvellousWorks.PracticalPattern.AbstractFactory.ProductSet2
{
    /// <summary>
    /// 定义不同类型的抽象产品
    /// </summary>
    public interface IProductA { }
    public interface IProductB { }
    public interface IProductC { }


    /// <summary>
    /// 定义实体产品
    /// </summary>
    public class ProductA1 : IProductA { }
    public class ProductA2X : IProductA { }
    public class ProductA2Y : IProductA { }
    public class ProductB1 : IProductB { }
    public class ProductB2 : IProductB { }
    public class ProductC1 : IProductC { }
    public class ProductC2 : IProductC { }
}
