using System;
namespace MarvellousWorks.PracticalPattern.AbstractFactory.Sync
{
    public delegate void ObjectCreateHandler<T>(T newProduct);

    public interface IFactory
    {
        IProduct Create();
    }
    public interface IFactoryWithNotifier : IFactory
    {
        void Create(ObjectCreateHandler<IProduct> callback);
    }
}
