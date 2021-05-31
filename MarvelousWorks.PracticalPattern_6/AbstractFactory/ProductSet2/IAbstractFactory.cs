using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.AbstractFactory.ProductSet2
{
public interface IAbstractFactory
{
    T Create<T>() where T : class;
}

public abstract class AbstractFactoryBase : IAbstractFactory
{
    // 外部机制通过配置获取的“抽象类型/实体类型”映射字典
    protected IDictionary<Type, Type> mapper;

    public AbstractFactoryBase(IDictionary<Type, Type> mapper) // 构造函数注入
    {
        this.mapper = mapper;
    }

    public virtual T Create<T>() where T : class
    {
        if ((mapper == null) || (mapper.Count == 0)|| (!mapper.ContainsKey(typeof(T))))
            throw new ArgumentException("T");
        Type targetType = mapper[typeof(T)];
        return (T)Activator.CreateInstance(targetType);
    }
}

public class ConcreteFactory : AbstractFactoryBase
{
    public ConcreteFactory(IDictionary<Type, Type> mapper) : base(mapper) { }
}
}
