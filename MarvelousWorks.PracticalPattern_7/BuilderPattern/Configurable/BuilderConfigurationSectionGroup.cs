using System;
using System.Collections.Generic;
using System.Configuration;
namespace MarvellousWorks.PracticalPattern.BuilderPattern.Configurable
{
    /// <summary>
    /// 构造器模式所有配置内容的根配置节对象
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
