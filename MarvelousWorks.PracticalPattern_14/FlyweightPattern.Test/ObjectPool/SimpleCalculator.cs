#region using
using System;
using System.Collections.Generic;
using System.Text;
using MarvellousWorks.PracticalPattern.FlyweightPattern.ObjectPool;
#endregion
namespace FlyweightPattern.Test.ObjectPool
{
    /// <summary>
    /// �򵥵Ŀɳػ�������󣬽�֧�� + \ -
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
