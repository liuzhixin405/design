using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.CommandPattern.Federate
{
    /// <summary>
    /// 经典模式下的Command接口
    /// </summary>
    public interface ICommand
    {
        void Execute();
    }
}
