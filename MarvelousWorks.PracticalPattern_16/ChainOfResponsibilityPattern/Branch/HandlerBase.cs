using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.ChainOfResponsibilityPattern.Branch
{
    /// <summary>
    /// 操作的抽象类型
    /// </summary>
    public abstract class HandlerBase : IHandler
    {
        protected IList<IHandler> successors = new List<IHandler>();
        protected PurchaseType type;

        public HandlerBase(PurchaseType type)
        {
            this.type = type;
        }

        public PurchaseType Type { get { return type; } set { type = value; } }

        /// <summary>
        /// 需要具体IHandler类型处理的内容
        /// </summary>
        /// <param name="price"></param>
        public abstract void Process(Request request);

        /// <summary>
        /// 按照链式方式依次把调用继续下去
        /// </summary>
        /// <param name="request"></param>
        public virtual void HandleRequest(Request request)
        {
            if (request == null) return;
            if (request.Type == Type)
                Process(request);
            else
                if (Successors.Count > 0)
                    foreach(IHandler successor in Successors)
                        successor.HandleRequest(request);
        }

        /// <summary>
        /// 当前节点的各个分支后继
        /// </summary>
        public virtual IList<IHandler> Successors { get { return successors; } }
        public void AddSuccessor(IHandler successor)
        {
            if (successor == null) throw new ArgumentNullException("successor");
            Successors.Add(successor);
        }
    }
}
