using System;
using System.Configuration;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.ShowCase.Builders
{
    /// <summary>
    /// 连接串构造过程中一个具体的处理算法
    /// </summary>
    public abstract class ConnectionStringStrategyBase
    {
        /// <summary>
        /// 交给子类实现的算法具体处理结果
        /// </summary>
        /// <returns></returns>
        public abstract void Process(ref ConnectionStringSettings setting);
    }
}
