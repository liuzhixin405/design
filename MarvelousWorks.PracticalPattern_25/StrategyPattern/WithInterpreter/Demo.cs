using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.StrategyPattern.WithInterpreter
{

    public enum RuleFocus
    {
        Speed,      // 关注于速度
        Simplicity  // 关注于实现简单
    }

    /// <summary>
    /// 抽象策略对象
    /// </summary>
    public interface IStrategy
    {
        int[] Sort(int[] data);
    }

    /// <summary>
    /// 抽象Context对象
    /// </summary>
    public interface IContext
    {
        IStrategy Strategy { get; set;}

    }
}
