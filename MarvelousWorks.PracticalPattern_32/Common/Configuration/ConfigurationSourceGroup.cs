using System;
using System.Collections.Generic;
using System.Configuration;
namespace MarvellousWorks.PracticalPattern.Common.Configuration
{
    /// <summary>
    /// 表示当前 common block 的配置节组
    /// </summary>
    class ConfigurationSourceGroup : ConfigurationSectionGroup, IConfigurationSource
    {
        private const string ObjectBuilderItem = "objectBuilder";
        public ConfigurationSourceGroup() : base() { }

        /// <summary>
        /// 用于动态生成 IObjectBuilder 的配置节
        /// </summary>
        [ConfigurationProperty(ObjectBuilderItem, IsRequired=true)]
        public ObjectBuilderConfigurationSource ObjectBuilder
        {
            get
            {
                return base.Sections[ObjectBuilderItem] as ObjectBuilderConfigurationSource;
            }
        }

        public void Load()
        {
            Type type = System.Type.GetType(ObjectBuilder.TypeName);
            ConfigurationBroker.Add(typeof(IObjectBuilder), Activator.CreateInstance(type));
        }
    }
}
