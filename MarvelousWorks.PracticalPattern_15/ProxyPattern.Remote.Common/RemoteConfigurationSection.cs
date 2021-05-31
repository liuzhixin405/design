using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
namespace MarvellousWorks.PracticalPattern.ProxyPattern.Remote.Common
{
    public class RemoteConfigurationSection<TData>
    {
        private const string SectionName = "marvellousWorks.practicalPattern.proxyProcessHandler";
        private IList<ProcessHandler<TData>> preProcess = null;
        private IList<ProcessHandler<TData>> postProcess = null;

        /// <summary>
        /// 访问配置，并完成委托的关联过程
        /// </summary>
        public RemoteConfigurationSection()
        {
            if (Handlers != null)
            {
                preProcess = new List<ProcessHandler<TData>>();
                postProcess = new List<ProcessHandler<TData>>();
                foreach(IProcess<TData> process in Handlers)
                {
                    preProcess.Add(new ProcessHandler<TData>(process.PreProcess));
                    postProcess.Add(new ProcessHandler<TData>(process.PostProcess));
                }
                // 处理上，为了保证数据的一致性，需要在PostProcess的过程翻转
                ProcessHandler<TData>[] buffer = new ProcessHandler<TData>[postProcess.Count];
                postProcess.CopyTo(buffer, 0);
                Array.Reverse(buffer);
                postProcess = new List<ProcessHandler<TData>>(buffer);
            }
        }

        public IList<ProcessHandler<TData>> PreProcess { get { return this.preProcess; } }
        public IList<ProcessHandler<TData>> PostProcess { get { return this.postProcess; } }

        public IList<IProcess<TData>> Handlers
        {
            get
            {
                NameValueCollection section = (NameValueCollection)ConfigurationManager.GetSection(SectionName);
                if ((section == null) || (section.Count == 0)) return null;
                IList<IProcess<TData>> list = new List<IProcess<TData>>();
                foreach (string key in section.AllKeys)
                {
                    Type type = Type.GetType(section[key]);
                    IProcess<TData> process = (IProcess<TData>)Activator.CreateInstance(type);
                    list.Add(process);
                }
                return list;
            }
        }
    }
}
