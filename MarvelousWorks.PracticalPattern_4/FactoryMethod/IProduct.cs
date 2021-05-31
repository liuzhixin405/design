namespace MarvellousWorks.PracticalPattern.FactoryMethod
{
    /// <summary>
    /// 抽象产品类型
    /// </summary>
    public interface IProduct
    {
        string Name { get;}     // 约定的抽象产品所必须具有的特征
    }

    /// <summary>
    /// 具体产品类型
    /// </summary>
    public class ProductA : IProduct
    {
        public string Name { get { return "A"; } }
    }
    /// <summary>
    /// 具体产品类型
    /// </summary>
    public class ProductB : IProduct
    {
        public string Name { get { return "B"; } }
    }
}
