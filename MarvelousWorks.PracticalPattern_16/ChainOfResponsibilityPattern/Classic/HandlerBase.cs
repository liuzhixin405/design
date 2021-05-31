using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.ChainOfResponsibilityPattern.Classic
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
            if (request == null) return;
            if (request.Type == Type)
                Process(request);
            else
                if (Successor != null)
                    successor.HandleRequest(request);
        }
    }
}
