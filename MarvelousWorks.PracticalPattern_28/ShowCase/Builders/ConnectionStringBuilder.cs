using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
namespace MarvellousWorks.PracticalPattern.ShowCase.Builders
{
    /// <summary>
    /// ���������Ӵ���Builder
    /// </summary>
    class ConnectionStringBuilder
    {
        /// <summary>
        /// ��Ҫ�������Ӵ��Ĳ��Զ���
        /// </summary>
        public IList<KeyValuePair<string, ConnectionStringStrategyBase>> strategies;
        public virtual IList<KeyValuePair<string, ConnectionStringStrategyBase>> Strategies
        {
            get { return strategies; }
        }

        public ConnectionStringBuilder(NameValueCollection collection)
        {
            strategies = new List<KeyValuePair<string, ConnectionStringStrategyBase>>();
            foreach (string key in collection.Keys)
            {
                string typeName = collection[key];
                Type type = Type.GetType(typeName);
                ConnectionStringStrategyBase strategy = 
                    (ConnectionStringStrategyBase)Activator.CreateInstance(type);
                strategies.Add(new KeyValuePair<string, ConnectionStringStrategyBase>(
                    key, strategy));
            }
        }

        /// <summary>
        /// ������Ӵ����õĸ���
        /// ���������ļ��Ķ���������Ǹ������ڹ���Ļ��ƣ�Ϊ�˱����ⲿ����ֱ�ӻ��
        /// �޸ĺ�����ý��������ĳЩ��Ϣ��й©������Ҫ���ڴ��б���һ������������
        /// ������������Builder���д���
        /// </summary>
        /// <returns></returns>
        private IDictionary<string, ConnectionStringSettings> GetConnectionsCopy()
        {
            IDictionary<string, ConnectionStringSettings> result =
                new Dictionary<string, ConnectionStringSettings>();
            foreach (ConnectionStringSettings setting in
                ConfigurationManager.ConnectionStrings)
            {
                ConnectionStringSettings settingCopy = new ConnectionStringSettings(
                    setting.Name, setting.ConnectionString, setting.ProviderName);
                result.Add(setting.Name, settingCopy);
            }
            return result;
        }

        /// <summary>
        /// �����Ӵ����ö����������󷵻�
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, ConnectionStringSettings> BuildUp()
        {
            IDictionary<string, ConnectionStringSettings> result = GetConnectionsCopy();
            if ((Strategies != null) && (Strategies.Count > 0))
            {
                foreach (KeyValuePair<string, ConnectionStringStrategyBase> pair in Strategies)
                {
                    string name = pair.Key;
                    ConnectionStringSettings setting = result[name];
                    ConnectionStringStrategyBase strategy = pair.Value;
                    strategy.Process(ref setting);
                }
            }
            return result;
        }
    }
}
