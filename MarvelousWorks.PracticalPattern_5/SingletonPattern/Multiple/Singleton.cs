using System;
using System.Threading;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.SingletonPattern.Multiple
{
    /// <summary>
    /// 实例的执行状况
    /// </summary>
    public enum Status
    {
        Busy,   // 被客户程序占用
        Free    // 没有被客户程序占用
    }

    interface IWorkItem
    {
        Status Status { get; set;}
        void DeActivate();  // 某个类型实例放弃使用的方法
    }

    class WorkItemCollection<T>
        where T : class, IWorkItem
    {
        /// <summary>
        /// 定义最多允许保存的实例数量N
        /// </summary>
        protected int max;
        protected IList<T> items = new List<T>();
        public WorkItemCollection(int max) { this.max = max; }

        /// <summary>
        /// 外部获得 T 类型实例的入口
        /// </summary>
        /// <returns></returns>
        public virtual T GetWorkItem()
        {
            if((items == null) || (items.Count == 0)) return null;

            // 可能的话，对外反馈一个现成实例
            foreach(T item in items)
                if (item.Status == Status.Free)
                {
                    item.Status = Status.Busy;
                    return item;
                }

            return null;    // 如果虽然有现成的实例，但都忙着就返回null
        }

        /// <summary>
        /// 新增一个类型
        /// </summary>
        /// <param name="item"></param>
        public virtual void Add(T item)
        {
            if (item == null) throw new ArgumentNullException("item");
            if (!CouldAddNewInstance) throw new OverflowException();
            item.Status = Status.Free;  // 默认状态
            items.Add(item);
        }

        /// <summary>
        /// 判断是否可以增加新的实例
        /// </summary>
        public virtual bool CouldAddNewInstance { get { return (items.Count < max); } }
    }
    
    public class SingletonN : IWorkItem
    {
        private const int MaxInstance = 2;  // 定义Singleton-N的这个N

        private Status status = Status.Free;    // 初始状态
        public void DeActivate() { this.status = Status.Free; }
        public Status Status 
        {
            get { return this.status; }
            set { this.status = value; }
        }

        private static WorkItemCollection<SingletonN> collection = new WorkItemCollection<SingletonN>(MaxInstance);
        private SingletonN() { }
        public static SingletonN Instance
        {
            get
            {
                // 在基本实现框架不变的情况下，引入集合实现Singleton-N的多个实例对象管理
                SingletonN instance = collection.GetWorkItem();
                if (instance == null)
                    if (!collection.CouldAddNewInstance)
                        return null;
                    else
                    {
                        instance = new SingletonN();
                        collection.Add(instance);
                    }
                instance.Status = Status.Busy; // 激活使用
                return instance;
            }
        }
    }
}
