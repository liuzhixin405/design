using System;
using System.Collections.Generic;
using System.Configuration;
namespace MarvellousWorks.PracticalPattern.ChainOfResponsibilityPattern.Configuration
{
    /// <summary>
    /// ≈‰÷√Ω⁄
    /// </summary>
    class ChannelConfigurationSection : ConfigurationSection
    {
        public const string Name = "channel";

        [ConfigurationProperty(HandlerConfigurationElementCollection.Name, 
            IsRequired = true)]
        public HandlerConfigurationElementCollection Handlers{get{
                return this[HandlerConfigurationElementCollection.Name]
                    as HandlerConfigurationElementCollection;}
        }
    }
}
