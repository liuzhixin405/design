#region using
using System;
using System.Collections.Generic;
using System.Text;
using MarvellousWorks.PracticalPattern.FlyweightPattern.ObjectPool;
#endregion
namespace FlyweightPattern.Test.ObjectPool
{
    /// <summary>
    /// ��΢���ӵĵĿɳػ�������󣬽�֧�� *
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
