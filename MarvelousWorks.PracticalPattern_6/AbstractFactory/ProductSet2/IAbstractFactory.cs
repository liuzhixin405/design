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
    // �ⲿ����ͨ�����û�ȡ�ġ���������/ʵ�����͡�ӳ���ֵ�
    protected IDictionary<Type, Type> mapper;

    public AbstractFactoryBase(IDictionary<Type, Type> mapper) // ���캯��ע��
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
