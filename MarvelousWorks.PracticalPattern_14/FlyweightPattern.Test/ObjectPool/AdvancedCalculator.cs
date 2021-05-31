#region using
using System;
using System.Collections.Generic;
using System.Text;
using MarvellousWorks.PracticalPattern.FlyweightPattern.ObjectPool;
#endregion
namespace FlyweightPattern.Test.ObjectPool
{
    /// <summary>
    /// 稍微复杂的的可池化计算对象，仅支持 *
    /// </summary>
    public class AdvancedCalculator : PoolableBase
    {
        public int Multiple(int x, int y)
        {
            PreProcess();
            return x * y;
        }
    }
}
