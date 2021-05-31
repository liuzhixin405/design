using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.ChainOfResponsibilityPattern.BreakPoint
{
    /// <summary>
    /// 操作的抽象类型
    /// </summary>
    public abstract class HandlerBase : IHandler
    {
        protected IHandler successor;
        protected PurchaseType type;

        public HandlerBase(PurchaseType type, IHandler successor)
        {
            this.type = type;
            this.successor = successor;
        }

        public HandlerBase(PurchaseType type) : this(type, null) { }
        public IHandler Successor { get { return successor; } set { successor = value; } }
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
            // 如果发现当前操作设置了断点，则抛出事件
            if (HasBreakPoint)
                OnBreak(new CallHandlerEventArgs(this, request));

            if (request == null) return; 
            if (request.Type == Type)
                Process(request);
            else
                if (Successor != null)
                    successor.HandleRequest(request);
        }

        /// <summary>
        /// 执行过程中动态提示TraceManager对当前断点响应
        /// </summary>
        protected bool hasBreakPoint;
        public virtual bool HasBreakPoint
        {
            get { return hasBreakPoint; }
            set { hasBreakPoint = value; }
        }

        /// <summary>
        /// 断点事件响应
        /// </summary>
        public event EventHandler<CallHandlerEventArgs> Break;
        public virtual void OnBreak(CallHandlerEventArgs args)
        {
            if (Break != null)
                Break(this, args);
        }
    }
}
