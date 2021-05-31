#region using
using System;
using System.Collections.Generic;
using System.Text;
using MarvellousWorks.PracticalPattern.FlyweightPattern.ObjectPool;
#endregion
namespace FlyweightPattern.Test.ObjectPool
{
    /// <summary>
    /// 简单的可池化计算对象，仅支持 + \ -
    /// </summary>
    public class SimpleCalculator : PoolableBase
    {
        public int Add(int x, int y)
        {
            PreProcess();
            return x + y;
        }
        public int Substract(int x, int y)
        {
            PreProcess();
            return x - y;
        }
    }
}
