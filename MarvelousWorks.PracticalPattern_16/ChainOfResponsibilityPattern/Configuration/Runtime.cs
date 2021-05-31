using System;
using System.Collections.Generic;
using System.Configuration;
namespace MarvellousWorks.PracticalPattern.ChainOfResponsibilityPattern.Configuration
{
    /// <summary>
    /// ְ����������������
    /// </summary>
    public class Runtime
    {
        System.Configuration.Configuration config = ConfigurationManager.
            OpenExeConfiguration(ConfigurationUserLevel.None);

        /// <summary>
        /// ͨ�����������ļ���ñ��ź�ĸ���������
        /// 1����ͨ�������ļ��Ĳ�ι�ϵ��ö�Ӧ��<handlers>�ڵ�
        /// 2����������װְ����
        /// </summary>
        public IHandler Head
        {
            get
            {
                /// 1����ͨ�������ļ��Ĳ�ι�ϵ��ö�Ӧ��<handlers>�ڵ�
                CoRConfigurationSectionGroup group =
                    config.GetSectionGroup(CoRConfigurationSectionGroup.Name)
                as CoRConfigurationSectionGroup;
                HandlerConfigurationElementCollection coll = group.Channel.Handlers;

                /// 2����������װְ����
                if (coll.Count == 0) return null;
                if (coll.Count == 1) return coll[0].CreateInstance();   // ͷ�ڵ�
                IHandler head = coll[0].CreateInstance();               // ͷ�ڵ�
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
