using System;
using System.Collections.Generic;
using System.Configuration;
namespace MarvellousWorks.PracticalPattern.BuilderPattern.Configurable
{
    /// <summary>
    /// ����"name"���Ե�����Ԫ��
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
        /// ������Ż�ȡָ��������Ԫ��
        /// </summary>
        /// <param name="index">���</param>
        /// <returns>����Ԫ��</returns>
        public virtual T this[int index] { get { return (T)base.BaseGet(index); } }

        /// <summary>
        /// �������ƻ�ȡָ��������Ԫ��
        /// </summary>
        /// <param name="name">����</param>
        /// <returns>����Ԫ��</returns>
        public new T this[string name] { get { return (T)base.BaseGet(name); } }

        /// <summary>
        /// �Ƿ����ָ��������Ԫ��
        /// </summary>
        public bool ContainsKey(string name) { return BaseGet(name) != null; }

        /// <summary>
        /// �õ�Ԫ�ص�Keyֵ
        /// </summary>
        /// <param name="element">����Ԫ��</param>
        /// <returns>����Ԫ������Ӧ������Ԫ��</returns>
        protected override object GetElementKey(ConfigurationElement element) { return ((T)element).Name; }

        /// <summary>
        /// �����µ�����Ԫ��ʵ��
        /// </summary>
        /// <returns></returns>
        protected override ConfigurationElement CreateNewElement() { return new T(); }
    }
}