using System;
using System.Collections.Generic;
using System.Diagnostics;
namespace MarvellousWorks.PracticalPattern.ChainOfResponsibilityPattern.Branch
{
    /// <summary>
    /// 抽象的操作对象
    /// </summary>
    public interface IHandler
    {
        /// <summary>
        /// 处理客户程序请求
        /// </summary>
        /// <param name="request"></param>
        void HandleRequest(Request request);

        /// <summary>
        /// 后继结点
        /// </summary>
        IList<IHandler> Successors { get;}

        /// <summary>
        /// 增加新的后继分支节点
        /// </summary>
        /// <param name="successor"></param>
        void AddSuccessor(IHandler successor);

        /// <summary>
        /// 当前Handler处理的请求类型
        /// </summary>
        PurchaseType Type { get; set;}
    }
}
