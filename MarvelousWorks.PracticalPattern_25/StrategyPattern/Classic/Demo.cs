using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.StrategyPattern.Classic
{
    /// <summary>
    /// 抽象策略对象
    /// </summary>
    public interface IStrategy
    {
        /// <summary>
        /// 算法需要完成的功能
        /// 这里是按照具体策略的要求，提取出某一个数据即可
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int PickUp(int[] data);
    }

    /// <summary>
    /// 抽象Context对象
    /// </summary>
    public interface IContext
    {
        IStrategy Strategy { get; set;}
        int GetData(int[] data);
    }
}
