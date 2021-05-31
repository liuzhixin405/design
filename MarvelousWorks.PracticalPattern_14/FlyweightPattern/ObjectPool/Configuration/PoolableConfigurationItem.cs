#region using
using System;
using System.Collections.Generic;
using System.Text;
#endregion
namespace MarvellousWorks.PracticalPattern.FlyweightPattern.ObjectPool.Configuration
{
    /// <summary>
    /// Poolable object configuration instance
    /// </summary>
    public struct PoolableConfigurationItem : IPoolableConfiguration
    {
        #region Private Field
        private int max;
        private int timeout;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="max"></param>
        /// <param name="timeout"></param>
        public PoolableConfigurationItem(int max, int timeout)
        {
            this.max = max;
            this.timeout = timeout;
        }

        #region Public Property
        public int Max 
        { 
            get { return max; } 
        }

        public int Timeout
        {
            get { return timeout; }
        }
        #endregion
    }
}
