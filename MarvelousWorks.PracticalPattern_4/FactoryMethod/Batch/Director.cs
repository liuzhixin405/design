using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.FactoryMethod.Batch
{
    public abstract class DecisionBase
    {
        protected IBatchFactory factory;
        protected int quantity;

        public DecisionBase(IBatchFactory factory, int quantity)
        {
            this.factory = factory;
            this.quantity = quantity;
        }

        public virtual IBatchFactory Factory { get { return factory; } }
        public virtual int Quantity { get { return quantity; } }
    }

    public abstract class DirectorBase
    {
        protected IList<DecisionBase> decisions = new List<DecisionBase>();

        /// <summary>
        /// 实际项目中，最好将每个Director需要添加的Decision也定义在配置文件中，
        /// 这样增加新的Decision项都在后台完成，而不需要Assembler显式调用该方法补充。
        /// </summary>
        /// <param name="decision"></param>
        protected virtual void Insert(DecisionBase decision)
        {
            if ((decision == null) || (decision.Factory == null) || (decision.Quantity < 0))
                throw new ArgumentException("decision");
            decisions.Add(decision);
        }

        /// <summary>
        /// 便于客户程序使用增加的迭代器
        /// </summary>
        public virtual IEnumerable<DecisionBase> Decisions
        {
            get { return decisions; }
        }
    }
}
