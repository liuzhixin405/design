#region using
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
#endregion
namespace MarvellousWorks.PracticalPattern.FlyweightPattern.ObjectPool.Configuration
{
    /// <summary>
    /// Root configuration section of ObjectPool
    /// </summary>
    class PoolableConfigurationSection : ConfigurationSection
    {
        public const string Name = "objectPool";

        /// <summary>
        /// Public property 
        /// </summary>
        [ConfigurationProperty(PoolableConfigurationElementCollection.Name)]
        public PoolableConfigurationElementCollection Settings
        {
            get
            {
                return base[PoolableConfigurationElementCollection.Name]
                    as PoolableConfigurationElementCollection;
            }
        }
    }
}
