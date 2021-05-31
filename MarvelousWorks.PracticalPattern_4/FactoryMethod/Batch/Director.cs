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
        /// ʵ����Ŀ�У���ý�ÿ��Director��Ҫ��ӵ�DecisionҲ�����������ļ��У�
        /// ���������µ�Decision��ں�̨��ɣ�������ҪAssembler��ʽ���ø÷������䡣
        /// </summary>
        /// <param name="decision"></param>
        protected virtual void Insert(DecisionBase decision)
        {
            if ((decision == null) || (decision.Factory == null) || (decision.Quantity < 0))
                throw new ArgumentException("decision");
            decisions.Add(decision);
        }

        /// <summary>
        /// ���ڿͻ�����ʹ�����ӵĵ�����
        /// </summary>
        public virtual IEnumerable<DecisionBase> Decisions
        {
            get { return decisions; }
        }
    }
}
