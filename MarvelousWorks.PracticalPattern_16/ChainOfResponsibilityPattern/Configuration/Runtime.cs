using System;
using System.Collections.Generic;
using System.Configuration;
namespace MarvellousWorks.PracticalPattern.ChainOfResponsibilityPattern.Configuration
{
    /// <summary>
    /// 职责链环境的运行类
    /// </summary>
    public class Runtime
    {
        System.Configuration.Configuration config = ConfigurationManager.
            OpenExeConfiguration(ConfigurationUserLevel.None);

        /// <summary>
        /// 通过访问配置文件获得编排后的各个处理类
        /// 1、先通过配置文件的层次关系获得对应的<handlers>节点
        /// 2、解析并组装职责链
        /// </summary>
        public IHandler Head
        {
            get
            {
                /// 1、先通过配置文件的层次关系获得对应的<handlers>节点
                CoRConfigurationSectionGroup group =
                    config.GetSectionGroup(CoRConfigurationSectionGroup.Name)
                as CoRConfigurationSectionGroup;
                HandlerConfigurationElementCollection coll = group.Channel.Handlers;

                /// 2、解析并组装职责链
                if (coll.Count == 0) return null;
                if (coll.Count == 1) return coll[0].CreateInstance();   // 头节点
                IHandler head = coll[0].CreateInstance();               // 头节点
                IHandler current = head;
                for (int i = 1; i < coll.Count; i++)
                {
                    IHandler handler = coll[i].CreateInstance();
                    current.Successor = handler;
                    current = handler;
                }
                return head;
            }
        }
    }
}
