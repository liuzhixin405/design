using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.ChainOfResponsibilityPattern.BreakPoint
{
    /// <summary>
    /// ��Ӧ�ϵ���¼�����
    /// </summary>
    public class CallHandlerEventArgs : EventArgs
    {
        private IHandler handler;
        private Request request;

        public IHandler Handler { get { return this.handler; } }
        public Request Request { get { return this.request; } }

        public CallHandlerEventArgs(IHandler handler, Request request) 
        {
            this.handler = handler;
            this.request = request;
        }
    }
}
