using System;
using System.Collections.Generic;
using Common;
using MarvellousWorks.PracticalPattern.WebServiceEventMonitor.Server;
namespace Server
{
    /// <summary>
    /// WCF服务端实体对象
    /// </summary>
    class MessageService : IMessage
    {
        public string GetID()
        {
            return MessageRegistry.ID;
        }

        public string GetTitle()
        {
            return MessageRegistry.Title;
        }
    }
}
