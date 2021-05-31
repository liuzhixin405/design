using System;
using System.Collections.Generic;
using System.Diagnostics;
namespace MarvellousWorks.PracticalPattern.ChainOfResponsibilityPattern.Configuration
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
    }
}
