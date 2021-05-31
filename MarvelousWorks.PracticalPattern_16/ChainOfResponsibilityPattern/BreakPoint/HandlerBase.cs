using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.ChainOfResponsibilityPattern.BreakPoint
{
    /// <summary>
    /// �����ĳ�������
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
        /// ��Ҫ����IHandler���ʹ��������
        /// </summary>
        /// <param name="price"></param>
        public abstract void Process(Request request);

        /// <summary>
        /// ������ʽ��ʽ���ΰѵ��ü�����ȥ
        /// </summary>
        /// <param name="request"></param>
        public virtual void HandleRequest(Request request)
        {
            // ������ֵ�ǰ���������˶ϵ㣬���׳��¼�
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
        /// ִ�й����ж�̬��ʾTraceManager�Ե�ǰ�ϵ���Ӧ
        /// </summary>
        protected bool hasBreakPoint;
        public virtual bool HasBreakPoint
        {
            get { return hasBreakPoint; }
            set { hasBreakPoint = value; }
        }

        /// <summary>
        /// �ϵ��¼���Ӧ
        /// </summary>
        public event EventHandler<CallHandlerEventArgs> Break;
        public virtual void OnBreak(CallHandlerEventArgs args)
        {
            if (Break != null)
                Break(this, args);
        }
    }
}
