using System;
namespace MarvellousWorks.PracticalPattern.FactoryMethod.Delegating
{
    public interface IFactory<T>
    {
        T Create();
    }

}
