#region using
using System;
using System.Collections.Generic;
using System.Text;

using MarvellousWorks.PracticalPattern.FlyweightPattern.ObjectPool;
#endregion
namespace MarvellousWorks.PracticalPattern.FlyweightPattern.ObjectPool.State
{
    /// <summary>
    /// ±»¼¤»î×´Ì¬
    /// </summary>
    public sealed class ActivatedState : StateBase
    {
        #region Singleton
        public static ActivatedState Instance;

        private ActivatedState() 
        {
        }

        static ActivatedState()
        {
            Instance = new ActivatedState();
        }
        #endregion

        public override bool Executable
        {
            get { return true; }
        }

        public override bool Unoccupied
        {
            get { return false; }
        }

        public override void Activate(IPoolable item)
        {
            throw new NotSupportedException();
        }

        public override void Deactivate(IPoolable item)
        {
            item.ChangeState(DeactivatedState.Instance);
        }
    }
}
