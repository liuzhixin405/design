#region using
using System;
using System.Collections.Generic;
using System.Text;

using MarvellousWorks.PracticalPattern.FlyweightPattern.ObjectPool;
#endregion
namespace MarvellousWorks.PracticalPattern.FlyweightPattern.ObjectPool.State
{
    /// <summary>
    /// ������ɵ�û�б�����״̬
    /// </summary>
    public sealed class ConstructedState : StateBase
    {
        #region Singleton
        public static ConstructedState Instance;

        private ConstructedState() 
        {
        }

        static ConstructedState()
        {
            Instance = new ConstructedState();
        }
        #endregion

        public override bool Executable
        {
            get { return false; }
        }

        public override bool Unoccupied
        {
            get { return true; }
        }

        public override void Activate(IPoolable item)
        {
            item.ChangeState(ActivatedState.Instance);
        }

        public override void Deactivate(IPoolable item)
        {
            throw new NotSupportedException();
        }
    }
}
