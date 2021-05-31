namespace MarvellousWorks.PracticalPattern.AbstractFactory.ComplexHierarchy
{
    public interface IProductXA { }
    public interface IProductXB { }
    public interface IProductYA { }
    public interface IProductYB { }
    public interface IProductYC { }

    public class ProductXA1 : IProductXA { }
    public class ProductXA2 : IProductXA { }
    public class ProductXA3 : IProductXA { }
    public class ProductXB1 : IProductXB { }
    public class ProductYA1 : IProductYA { }
    public class ProductYB1 : IProductYB { }
    public class ProductYB2 : IProductYB { }
    public class ProductYC1 : IProductYC { }

    public interface IAbstractFactory
    {
        T Create<T>();
    }
}
