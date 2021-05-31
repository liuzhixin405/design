using System;
using MarvellousWorks.PracticalPattern.FactoryMethod;
namespace MarvellousWorks.PracticalPattern.FactoryMethod.Batch
{
    /// <summary>
    /// �������������Ʒ�ӹ�����
    /// </summary>
    public interface IBatchFactory
    {
        /// <summary>
        /// ���������ĳ��󹤳���Ϊ����
        /// </summary>
        /// <param name="quantity">���ӹ��Ĳ�Ʒ����</param>
        /// <returns></returns>
        ProductCollection Create(int quantity);
    }

    /// <summary>
    /// Ϊ�˷�����չ�ṩ�ĳ������
    /// </summary>
    /// <typeparam name="T">Concrete Product����</typeparam>
    public class BatchProductFactoryBase<T> : IBatchFactory
        where T : IProduct, new()
    {
        public virtual ProductCollection Create(int quantity)
        {
            if (quantity <= 0) throw new ArgumentException();
            ProductCollection collection = new ProductCollection();
            for (int i = 0; i < quantity; i++) collection.Insert(new T());
            return collection;
        }
    }

    /// <summary>
    /// ����ʵ������������������
    /// </summary>
    public class BatchProductAFactory : BatchProductFactoryBase<ProductA> { }
    public class BatchProductBFactory : BatchProductFactoryBase<ProductB> { }
}
