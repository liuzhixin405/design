using System;
using System.Collections.Generic;
using System.Diagnostics;
namespace MarvellousWorks.PracticalPattern.ChainOfResponsibilityPattern.BreakPoint
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
        IHandler Successor { get; set;}

        /// <summary>
        /// 当前Handler处理的请求类型
        /// </summary>
        PurchaseType Type { get; set;}

        /// <summary>
        /// 是否设置当前IHandler对象的处理为断点
        /// </summary>
        bool HasBreakPoint { set; get;}

        /// <summary>
        /// 
        /// </summary>
        event EventHandler<CallHandlerEventArgs> Break;
    }
}
