using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Configuration;
namespace MarvellousWorks.PracticalPattern.ChainOfResponsibilityPattern.Configuration
{
    /// <summary>
    /// ����Ԫ�ؼ���
    /// </summary>
    [ConfigurationCollection(typeof(HandlerConfigurationElement),
    CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap)]
    class HandlerConfigurationElementCollection : ConfigurationElementCollection
    {
        public const string Name = "handlers";

        /// <summary>
        /// ��������Ԫ�ؼ��ϵĲ���
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public HandlerConfigurationElement this[int index]{get{
            return (HandlerConfigurationElement)base.BaseGet(index);}}
        public new HandlerConfigurationElement this[string name]{get{
            return base.BaseGet(name) as HandlerConfigurationElement;}}
        protected override ConfigurationElement CreateNewElement(){
            return new HandlerConfigurationElement();}
        protected override object GetElementKey(ConfigurationElement element){
            return (element as HandlerConfigurationElement).Type;}
    }
}
