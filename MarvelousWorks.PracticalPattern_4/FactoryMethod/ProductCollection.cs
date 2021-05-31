using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.FactoryMethod
{
    /// <summary>
    /// 装载IProduct的容器类型
    /// </summary>
    public class ProductCollection
    {
        private IList<IProduct> data = new List<IProduct>();

        /// <summary>
        /// 对外的集合操作方法
        /// </summary>
        /// <param name="item"></param>
        public void Insert(IProduct item) { data.Add(item); }
        public void Insert(IProduct[] items)    // 批量添加
        {
            if ((items == null) || (items.Length == 0)) return;
            foreach (IProduct item in items)
                data.Add(item);
        }
        public void Remove(IProduct item) { data.Remove(item); }
        public void Clear() { data.Clear(); }

        /// <summary>
        /// 获取所有IProduct内容的属性
        /// </summary>
        public IProduct[] Data
        {
            get
            {
                if ((data == null) || (data.Count == 0)) return null;
                IProduct[] result = new IProduct[data.Count];
                data.CopyTo(result, 0);
                return result;
            }
        }

        /// <summary>
        /// 当前集合内的元素数量
        /// </summary>
        public int Count { get { return data.Count; } }

        /// <summary>
        /// 为了便于操作，重载的运算符
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public static ProductCollection operator +(ProductCollection collection, IProduct[] items)
        {
            ProductCollection result = new ProductCollection();
            if (!((collection == null) || (collection.Count == 0))) result.Insert(collection.Data);
            if (!((items == null) || (items.Length == 0))) result.Insert(items);
            return result;
        }
        public static ProductCollection operator +(ProductCollection source, ProductCollection target)
        {
            ProductCollection result = new ProductCollection();
            if (!((source == null) || (source.Count == 0))) result.Insert(source.Data);
            if (!((target == null) || (target.Count == 0))) result.Insert(target.Data);
            return result;

        }
    }
}
