﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.1433
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MarvellousWorks.PracticalPattern.WebServiceEventMonitor.Client.MessageService
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MarvellousWorks.PracticalPattern.WebServiceEventMonitor.Client.MessageService.IMe" +
        "ssage")]
    public interface IMessage
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMessage/GetID", ReplyAction="http://tempuri.org/IMessage/GetIDResponse")]
        string GetID();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMessage/GetTitle", ReplyAction="http://tempuri.org/IMessage/GetTitleResponse")]
        string GetTitle();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface IMessageChannel : MarvellousWorks.PracticalPattern.WebServiceEventMonitor.Client.MessageService.IMessage, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class MessageClient : System.ServiceModel.ClientBase<MarvellousWorks.PracticalPattern.WebServiceEventMonitor.Client.MessageService.IMessage>, MarvellousWorks.PracticalPattern.WebServiceEventMonitor.Client.MessageService.IMessage
    {
        
        public MessageClient()
        {
        }
        
        public MessageClient(string endpointConfigurationName) : 
                base(endpointConfigurationName)
        {
        }
        
        public MessageClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public MessageClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public MessageClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public string GetID()
        {
            return base.Channel.GetID();
        }
        
        public string GetTitle()
        {
            return base.Channel.GetTitle();
        }
    }
}
