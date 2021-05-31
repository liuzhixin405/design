using System;
using System.Threading;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.SingletonPattern.Multiple
{
    /// <summary>
    /// ʵ����ִ��״��
    /// </summary>
    public enum Status
    {
        Busy,   // ���ͻ�����ռ��
        Free    // û�б��ͻ�����ռ��
    }

    interface IWorkItem
    {
        Status Status { get; set;}
        void DeActivate();  // ĳ������ʵ������ʹ�õķ���
    }

    class WorkItemCollection<T>
        where T : class, IWorkItem
    {
        /// <summary>
        /// ��������������ʵ������N
        /// </summary>
        protected int max;
        protected IList<T> items = new List<T>();
        public WorkItemCollection(int max) { this.max = max; }

        /// <summary>
        /// �ⲿ��� T ����ʵ�������
        /// </summary>
        /// <returns></returns>
        public virtual T GetWorkItem()
        {
            if((items == null) || (items.Count == 0)) return null;

            // ���ܵĻ������ⷴ��һ���ֳ�ʵ��
            foreach(T item in items)
                if (item.Status == Status.Free)
                {
                    item.Status = Status.Busy;
                    return item;
                }

            return null;    // �����Ȼ���ֳɵ�ʵ��������æ�žͷ���null
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="item"></param>
        public virtual void Add(T item)
        {
            if (item == null) throw new ArgumentNullException("item");
            if (!CouldAddNewInstance) throw new OverflowException();
            item.Status = Status.Free;  // Ĭ��״̬
            items.Add(item);
        }

        /// <summary>
        /// �ж��Ƿ���������µ�ʵ��
        /// </summary>
        public virtual bool CouldAddNewInstance { get { return (items.Count < max); } }
    }
    
    public class SingletonN : IWorkItem
    {
        private const int MaxInstance = 2;  // ����Singleton-N�����N

        private Status status = Status.Free;    // ��ʼ״̬
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
                // �ڻ���ʵ�ֿ�ܲ��������£����뼯��ʵ��Singleton-N�Ķ��ʵ���������
                SingletonN instance = collection.GetWorkItem();
                if (instance == null)
                    if (!collection.CouldAddNewInstance)
                        return null;
                    else
                    {
                        instance = new SingletonN();
                        collection.Add(instance);
                    }
                instance.Status = Status.Busy; // ����ʹ��
                return instance;
            }
        }
    }
}
