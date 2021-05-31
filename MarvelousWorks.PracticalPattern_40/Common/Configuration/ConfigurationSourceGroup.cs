using System;
using System.Collections.Generic;
using System.Configuration;
namespace MarvellousWorks.PracticalPattern.Common.Configuration
{
    /// <summary>
    /// ��ʾ��ǰ common block �����ý���
    /// </summary>
    class ConfigurationSourceGroup : ConfigurationSectionGroup, IConfigurationSource
    {
        private const string ObjectBuilderItem = "objectBuilder";
        public ConfigurationSourceGroup() : base() { }

        /// <summary>
        /// ���ڶ�̬���� IObjectBuilder �����ý�
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
