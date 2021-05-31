using System;
using System.Collections.Generic;
using System.Configuration;
namespace MarvellousWorks.PracticalPattern.BuilderPattern.Configurable
{
    /// <summary>
    /// 具有"name"属性的配置元素
    /// </summary>
    public class NamedConfigurationElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public virtual string Name { get { return (string)this["name"]; } }
    }

    public class NamedConfigurationElementCollection<T> : ConfigurationElementCollection
        where T : NamedConfigurationElement, new()
    {
        /// <summary>
        /// 按照序号获取指定的配置元素
        /// </summary>
        /// <param name="index">序号</param>
        /// <returns>配置元素</returns>
        public virtual T this[int index] { get { return (T)base.BaseGet(index); } }

        /// <summary>
        /// 按照名称获取指定的配置元素
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns>配置元素</returns>
        public new T this[string name] { get { return (T)base.BaseGet(name); } }

        /// <summary>
        /// 是否包含指定的配置元素
        /// </summary>
        public bool ContainsKey(string name) { return BaseGet(name) != null; }

        /// <summary>
        /// 得到元素的Key值
        /// </summary>
        /// <param name="element">配置元素</param>
        /// <returns>配置元素所对应的配置元素</returns>
        protected override object GetElementKey(ConfigurationElement element) { return ((T)element).Name; }

        /// <summary>
        /// 生成新的配置元素实例
        /// </summary>
        /// <returns></returns>
        protected override ConfigurationElement CreateNewElement() { return new T(); }
    }
}