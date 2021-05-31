using System;
using System.Collections.Generic;
using System.Diagnostics;
namespace MarvellousWorks.PracticalPattern.ChainOfResponsibilityPattern.Branch
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
        IList<IHandler> Successors { get;}

        /// <summary>
        /// �����µĺ�̷�֧�ڵ�
        /// </summary>
        /// <param name="successor"></param>
        void AddSuccessor(IHandler successor);

        /// <summary>
        /// ��ǰHandler�������������
        /// </summary>
        PurchaseType Type { get; set;}
    }
}
