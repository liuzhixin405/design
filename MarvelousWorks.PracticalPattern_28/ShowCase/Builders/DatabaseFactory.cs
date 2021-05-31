using System;
using System.Collections.Generic;
using System.Configuration;
namespace MarvellousWorks.PracticalPattern.ShowCase.Builders
{
    /// <summary>
    /// ����Database����Ĺ�����
    /// ͨ����̬��ʵ��Singleton
    /// </summary>
    public static class DatabaseFactory
    {
        private static DbProviderRegistry registry = new DbProviderRegistry();

        /// <summary>
        /// �ṩDatabase����Ĺ�������
        /// </summary>
        /// <param name="name">���ݿ��߼�����</param>
        /// <returns>Database����</returns>
        public static Database Create(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("name");
            ConnectionStringSettings setting = ConnectionManager.GetSetting(name);
            string providerName = setting.ProviderName;
            Type type = Type.GetType(registry.GetDbType(providerName));
            return (Database)Activator.CreateInstance(type, name);
        }
    }
}
