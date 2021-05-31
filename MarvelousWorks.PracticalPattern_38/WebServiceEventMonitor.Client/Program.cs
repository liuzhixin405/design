using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Timers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.WebServiceEventMonitor.Client.MessageService;
namespace WebServiceEventMonitor.Client
{
    /// <summary>
    /// Snapshot对象
    /// </summary>
    static class Snapshot
    {
        public const string IDItem = "ID";
        public const string TitleItem = "Title";

        private static IDictionary<string, string> dictionary =
            new Dictionary<string, string>();

        static Snapshot()
        {
            dictionary.Add(IDItem, string.Empty);
            dictionary.Add(TitleItem, string.Empty);
        }

        /// <summary>
        /// 鉴别新监控到的信息是否与快照信息相符
        /// </summary>
        /// <param name="key"></param>
        /// <param name="monitorValue"></param>
        /// <returns></returns>
        public static bool Equals(string key, string monitorValue)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException("key");
            if (!dictionary.ContainsKey(key)) throw new ArgumentException("cannot find item");
            bool isEqual = string.Equals(dictionary[key], monitorValue);

            // 根据最新的数据快照更新自身信息
            // 实际处理中这个操作也可以由EventMonitor发起
            if (!isEqual)
                dictionary[key] = monitorValue;

            return isEqual;
        }
    }

    #region 事件监控器
    class MonitorEventArgs : EventArgs
    {
        private string newValue;
        public string NewValue{get{return newValue;}}

        public MonitorEventArgs(string newValue)
        {
            this.newValue = newValue;
        }
    }

    class EventMonitor
    {
        private Timer timer;
        private MessageClient client;

        #region EventMonitor的监控频率
        private int interval;
        public int Interval
        {
            get { return interval; }
            set { interval = value; } 
        }
        #endregion

        #region 对外的预定事件
        public event EventHandler<MonitorEventArgs> IDChanged;
        public event EventHandler<MonitorEventArgs> TitleChanged;
        #endregion

        public EventMonitor(MessageClient client)
        {
            this.client = client;
            timer = new Timer(1000);
            timer.Elapsed += Refersh;
        }

        /// <summary>
        /// 轮循执行时执行的逻辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void Refersh(Object sender, ElapsedEventArgs args)
        {
            string id = client.GetID();
            string title = client.GetTitle();

            if (TitleChanged != null)
            {
                if (!Snapshot.Equals(Snapshot.TitleItem, title))
                    TitleChanged(this, new MonitorEventArgs(title));
            }

            if (IDChanged != null)
            {
                if (!Snapshot.Equals(Snapshot.IDItem, id))
                    IDChanged(this, new MonitorEventArgs(id));
            }
        }

        public void Start()
        {
            timer.Elapsed += Refersh;
            timer.Enabled = true;
        }

        public void Stop()
        {
            timer.Enabled = false;
        }
    }
    #endregion


    class Program
    {
        static void OnIDChanged(object sender, MonitorEventArgs args)
        {
            Console.WriteLine("[NEW ID] " + args.NewValue);
        }

        static void OnTitleChanged(Object sender, MonitorEventArgs args)
        {
            Console.WriteLine("[NEW Title] " + args.NewValue);
        }

        static void Main(string[] args)
        {
            using (MessageClient client = new MessageClient())
            {
                Console.WriteLine("Press any key when service started ...");
                Console.ReadLine();
                EventMonitor moitor = new EventMonitor(client);

                // 预定更新通知
                moitor.TitleChanged += OnTitleChanged;
                moitor.IDChanged += OnIDChanged;

                moitor.Start();
                Console.ReadLine();
            }
        }   
    }
}
