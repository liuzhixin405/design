using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
namespace MarvellousWorks.PracticalPattern.ShowCase.Builders
{
    /// <summary>
    /// 负责构造连接串的Builder
    /// </summary>
    class ConnectionStringBuilder
    {
        /// <summary>
        /// 需要处理连接串的策略对象
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
        /// 获得连接串配置的副本
        /// 由于配置文件的对象的内容是个进程内共享的机制，为了避免外部程序直接获得
        /// 修改后的配置结果，避免某些信息的泄漏，所以要在内存中保存一个副本，并在
        /// 副本基础上用Builder进行处理
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
        /// 对连接串配置对象逐个处理后返回
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
