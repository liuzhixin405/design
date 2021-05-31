using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Threading;
namespace Common
{
    /// <summary>
    /// �Զ����Message Interceptering Filter
    /// </summary>
    public class QuotePriceFilter : 
        IClientMessageInspector,    // ����ͻ��˵����ش���
        IDispatchMessageInspector   // �������˵����ش���
    {
        private const string Key = "signature";
        private const string Signature = "MarvellousWorks";

        #region IDispatchMessageInspector Members
        /// <summary>
        /// �Ե��������������
        /// <remarks>��������һ���򵥵���Ϣͷ��֤��ʩ</remarks>
        /// </summary>
        /// <param name="request"></param>
        /// <param name="channel"></param>
        /// <param name="instanceContext"></param>
        /// <returns></returns>
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, 
            InstanceContext instanceContext)
        {
            int index = request.Headers.FindHeader(Key, string.Empty);
            if (index != -1) // Found
            {
                string signature = request.Headers.GetHeader<string>(index);
                if (!string.Equals(Signature, signature))
                    Console.WriteLine("message is not validate");
                else
                    Console.WriteLine("message signature verified");
            }
            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
        }
        #endregion

        #region IClientMessageInspector Members
        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
        }

        /// <summary>
        /// �Ե��������������
        /// </summary>
        /// <remarks>������������Ϣͷ����һЩ������Ϣ</remarks>
        /// <param name="request"></param>
        /// <param name="channel"></param>
        /// <returns></returns>
        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            request.Headers.Add(MessageHeader.CreateHeader(Key, string.Empty, Signature));
            return null;
        }
        #endregion
    }

    /// <summary>
    /// �Զ����Endpoint Behavior
    /// </summary>
    public class QuoteFilterBehaviour : IEndpointBehavior
    {
        public void AddBindingParameters(ServiceEndpoint endpoint, 
            BindingParameterCollection bindingParameters)
        {
        }

        public void Validate(ServiceEndpoint endpoint)
        {
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, 
            ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(new QuotePriceFilter());
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, 
            EndpointDispatcher endpointDispatcher)
        {
            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(
                new QuotePriceFilter());
        }
    }
}
