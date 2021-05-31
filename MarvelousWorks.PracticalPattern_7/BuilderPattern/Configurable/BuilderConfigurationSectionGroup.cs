using System;
using System.Collections.Generic;
using System.Configuration;
namespace MarvellousWorks.PracticalPattern.BuilderPattern.Configurable
{
    /// <summary>
    /// ������ģʽ�����������ݵĸ����ýڶ���
    /// </summary>
    public class BuilderConfigurationSectionGroup : ConfigurationSectionGroup
    {
        public BuilderConfigurationSectionGroup() : base() { }

        [ConfigurationProperty("customProducts")]
        public CustomProductConfigurationSection CustomProducts
        {
            get { return base.Sections["customProducts"] as CustomProductConfigurationSection; }
        }
    }
}
