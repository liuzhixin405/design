using System;
using System.Collections.Generic;
using System.Configuration;
namespace MarvellousWorks.PracticalPattern.ChainOfResponsibilityPattern.Configuration
{
    /// <summary>
    /// ����ÿ��IHandler������Ԫ��
    /// </summary>
    class HandlerConfigurationElement : ConfigurationElement
    {
        [ConfigurationProperty("type", IsRequired=true, IsKey=true)]
        public string Type { get { return base["type"] as string; } }
        
        /// <summary>
        /// �������õ�����,��������ʵ��
        /// </summary>
        public IHandler CreateInstance()
        {
            return (IHandler)(Activator.CreateInstance(System.Type.GetType(Type)));
        }
    }
}
