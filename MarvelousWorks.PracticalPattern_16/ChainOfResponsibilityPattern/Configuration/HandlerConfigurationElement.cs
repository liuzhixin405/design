using System;
using System.Collections.Generic;
using System.Configuration;
namespace MarvellousWorks.PracticalPattern.ChainOfResponsibilityPattern.Configuration
{
    /// <summary>
    /// 定义每个IHandler的配置元素
    /// </summary>
    class HandlerConfigurationElement : ConfigurationElement
    {
        [ConfigurationProperty("type", IsRequired=true, IsKey=true)]
        public string Type { get { return base["type"] as string; } }
        
        /// <summary>
        /// 根据配置的类型,生成类型实例
        /// </summary>
        public IHandler CreateInstance()
        {
            return (IHandler)(Activator.CreateInstance(System.Type.GetType(Type)));
        }
    }
}
