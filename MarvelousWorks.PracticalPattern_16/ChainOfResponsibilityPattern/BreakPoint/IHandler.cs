using System;
using System.Collections.Generic;
using System.Diagnostics;
namespace MarvellousWorks.PracticalPattern.ChainOfResponsibilityPattern.BreakPoint
{
    /// <summary>
    /// ����Ĳ�������
    /// </summary>
    public interface IHandler
    {
        /// <summary>
        /// ����ͻ���������
        /// </summary>
        /// <param name="request"></param>
        void HandleRequest(Request request);

        /// <summary>
        /// ��̽��
        /// </summary>
        IHandler Successor { get; set;}

        /// <summary>
        /// ��ǰHandler�������������
        /// </summary>
        PurchaseType Type { get; set;}

        /// <summary>
        /// �Ƿ����õ�ǰIHandler����Ĵ���Ϊ�ϵ�
        /// </summary>
        bool HasBreakPoint { set; get;}

        /// <summary>
        /// 
        /// </summary>
        event EventHandler<CallHandlerEventArgs> Break;
    }
}
