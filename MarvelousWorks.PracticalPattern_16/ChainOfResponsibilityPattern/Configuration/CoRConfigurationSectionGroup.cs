using System;
using System.Collections.Generic;
using System.Configuration;
namespace MarvellousWorks.PracticalPattern.ChainOfResponsibilityPattern.Configuration
{
    /// <summary>
    /// ���ý���
    /// </summary>
    class CoRConfigurationSectionGroup : ConfigurationSectionGroup
    {
        public const string Name = "marvellousWorks.practicalPattern.chain";

        public CoRConfigurationSectionGroup() : base() { }

        [ConfigurationProperty(ChannelConfigurationSection.Name, 
            IsRequired = true)]
        public ChannelConfigurationSection Channel
        {
            get { return Sections[ChannelConfigurationSection.Name] 
                as ChannelConfigurationSection; }
        }
    }
}
