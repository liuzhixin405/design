using System;
using System.Collections.Generic;
using System.Timers;
using Server;
using System.ServiceModel;
namespace MarvellousWorks.PracticalPattern.WebServiceEventMonitor.Server
{
    /// <summary>
    /// 用于模拟的具有动态信息更新能力的注册表对象
    /// </summary>
    static class MessageRegistry
    {
        /// <summary>
        /// 业务信息内容
        /// </summary>
        public static string ID = string.Empty;
        public static string Title = string.Empty;

        /// <summary>
        /// 触发更新的Timer
        /// </summary>
        private static Timer timer;

        static void UpdateID(Object sender, ElapsedEventArgs args)
        {
            if(string.IsNullOrEmpty(Title))
                Title = "MarvellousWorks"; 
            MessageRegistry.ID = Guid.NewGuid().ToString();
        }

        static MessageRegistry()
        {
            timer = new Timer(1000);
            timer.Elapsed += UpdateID;
            timer.Enabled = true;
        }
    }

    class Program
    {
        public static void Main()
        {
            using (ServiceHost host = new ServiceHost(typeof(MessageService)))
            {
                host.Open();
                Console.WriteLine("Service started ...");
                Console.ReadLine();
            }
        }
    }
}
