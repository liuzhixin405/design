using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.FactoryMethod.Generics
{
    /// <summary>
    /// ����ķ��͹�������
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IFactory<T>
    {
        T Create();
    }

    public abstract class FactoryBase<T> : IFactory<T>
        where T : new()
    {
        /// <summary>
        /// �������������Ŀ���Ӧ�ø��ʱȽ�С�����Ĭ��ʵ���˵�����Ʒ�Ĺ���
        /// </summary>
        /// <returns></returns>
        public virtual T Create()
        {
            return new T();
        }
    }

    /// <summary>
    /// ����������Ʒ��ʵ�幤��
    /// </summary>
    public class ProductAFactory : FactoryBase<ProductA> { }
    public class ProductBFactory : FactoryBase<ProductB> { }

    /// <summary>
    /// ����������Ʒ�����ĳ�����
    /// </summary>
    /// <typeparam name="TCollection"></typeparam>
    /// <typeparam name="TItem"></typeparam>
    public abstract class BatchFactoryBase<TCollection, TItem> : FactoryBase<TCollection>
        where TCollection : ProductCollection, new()
        where TItem : IProduct, new()
    {
        protected int quantity;
        public virtual int Quantity { set { this.quantity = value; } }

        public override TCollection Create()
        {
            if (quantity <= 0) throw new ArgumentException("quantity");
            TCollection collection = new TCollection();
            for (int i = 0; i < quantity; i++)
                collection.Insert(new TItem());
            return collection;
        }
    }

    /// <summary>
    /// ����������Ʒ��ʵ�幤��
    /// </summary>
    public class BatchProductAFactory : BatchFactoryBase<ProductCollection, ProductA> { }
    public class BatchProductBFactory : BatchFactoryBase<ProductCollection, ProductB> { }
}
