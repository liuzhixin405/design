using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.StrategyPattern.Mini
{
    public interface IBusinessObject
    {
        int ID { get; }
        string Name { get;}
    }

    public abstract class BusinessObjectBase : IBusinessObject
    {
        protected int id;
        protected string name;

        public virtual int ID { get { return id; } }
        public virtual string Name { get { return name; } }

        public BusinessObjectBase(int id, string name)
        {
            this.name = name;
            this.id = id;
        }
    }

    /// <summary>
    /// 自定义的抽象Context接口
    /// </summary>
    public interface IBusinessObjectCollection
    {
        IComparer<IBusinessObject> Comparer { get; set;}
        void Add(IBusinessObject obj);
        IEnumerable<IBusinessObject> GetAll();
    }

}
