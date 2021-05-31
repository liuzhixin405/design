#region using
using System;
using System.IO;
using System.Collections;

using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Messaging;

using System.Diagnostics;

using Test.Rem.Common;
#endregion

namespace Test.Rem.ClientChannel
{
	#region BaseClientChannelSink
	internal class BaseClientChannelSink : BaseChannelObjectWithProperties, IClientChannelSink
	{
		#region private field
		private IClientChannelSink _nextSink = null;
		#endregion

		#region constructor
		public BaseClientChannelSink() : base(){}
		public BaseClientChannelSink(IClientChannelSink nextSink) : base()
		{
			_nextSink = nextSink;
		}
		#endregion

		#region implements IClientChannelSink
		public void ProcessMessage(
			IMessage msg,
			ITransportHeaders requestHeaders,
			Stream requestStream,
			out ITransportHeaders responseHeaders,
			out Stream responseStream
			)
		{
			#region call context
			if(requestHeaders[ChannelSinkCallContext.ChannelSinkCallContextHeader] == null)
			{
				ChannelSinkCallContext context = new ChannelSinkCallContext();
				context.UserName = Environment.UserDomainName + @"\" + Environment.UserName;
				requestHeaders[ChannelSinkCallContext.ChannelSinkCallContextHeader] = ChannelSinkCallContext.SerializeCallContextToString(context);
			}
			#endregion
			_nextSink.ProcessMessage(msg, requestHeaders, requestStream, out responseHeaders, out responseStream);
		}

		public Stream GetRequestStream(IMessage msg, ITransportHeaders headers)
		{
			return _nextSink.GetRequestStream(msg, headers);
		}

		public void AsyncProcessResponse(
			IClientResponseChannelSinkStack stack,
			object state,
			ITransportHeaders headers,
			Stream stream
			)
		{
			stack.AsyncProcessResponse(headers, stream);
		}

		public void AsyncProcessRequest(
			IClientChannelSinkStack stack,
			IMessage msg,
			ITransportHeaders headers,
			Stream stream
			)
		{
			stack.Push(this, null);
			_nextSink.AsyncProcessRequest(stack, msg, headers, stream);
		}

		public IClientChannelSink NextChannelSink
		{
			get{return _nextSink;}
		}
		#endregion
	}
	#endregion

	#region BaseClientChannelSinkProvider
	internal class BaseClientChannelSinkProvider : IClientChannelSinkProvider
	{
		#region private field
		private IClientChannelSinkProvider _next = null;
		#endregion

		#region constrcutor
		public BaseClientChannelSinkProvider() {}
		public BaseClientChannelSinkProvider(IDictionary properties, ICollection providerData)
		{
		}
		#endregion

		#region Imeplments IClientChannelSinkProvider
		public IClientChannelSink CreateSink(IChannelSender channel, string url, object channelData)
		{
			if(_next == null)
				return null;

			IClientChannelSink nextSink = _next.CreateSink(channel, url, channelData);
			return new BaseClientChannelSink(nextSink);
		}

		public IClientChannelSinkProvider Next
		{
			get{return _next;}
			set{_next = value;}
		}
		#endregion 
	}
	#endregion
}
