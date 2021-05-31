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

namespace Test.Rem.ServiceChannel
{
	#region BaseServerSink
	internal class BaseServerChannelSink : BaseChannelObjectWithProperties, IServerChannelSink
	{
		#region private field
		private IServerChannelSink _nextSink = null;
		#endregion

		#region constructor
		public BaseServerChannelSink() : base(){}
		public BaseServerChannelSink(IServerChannelSink nextSink) :base()
		{
			_nextSink = nextSink;
		}
		#endregion

		#region Implements IServerChannelSink
		public ServerProcessing ProcessMessage(
			IServerChannelSinkStack stack,
			IMessage requestMsg,
			ITransportHeaders requestHeaders,
			Stream requestStream,
			out IMessage responseMsg,
			out ITransportHeaders responseHeaders,
			out Stream responseStream
			)
		{
			stack.Push(this, null);
			#region CallContext
			if(requestHeaders[ChannelSinkCallContext.ChannelSinkCallContextHeader] != null)
			{
				string contextInfo = (string)(requestHeaders[ChannelSinkCallContext.ChannelSinkCallContextHeader]);
				ChannelSinkCallContext context = ChannelSinkCallContext.DeserializeCallContextFromString(contextInfo);
				Console.WriteLine(System.DateTime.Now.ToLocalTime() + "  User : [" + context.UserName + "] is calling a request ...");
			}
			#endregion

			ServerProcessing result = _nextSink.ProcessMessage(stack, requestMsg, requestHeaders, requestStream, out responseMsg, out responseHeaders, out responseStream);
			return result;
		}
		public void AsyncProcessResponse(
			IServerResponseChannelSinkStack stack,
			object state,
			IMessage msg,
			ITransportHeaders headers,
			Stream stream)
		{
			_nextSink.AsyncProcessResponse(stack, state, msg, headers, stream);
		}

		public Stream GetResponseStream(
			IServerResponseChannelSinkStack stack,
			object state,
			IMessage msg,
			ITransportHeaders header)
		{
			return null;
		}

		public IServerChannelSink NextChannelSink
		{
			get{return _nextSink;}
		}
		#endregion
	}
	#endregion

	#region BaseServerChannelSinkProvider
	internal class BaseServerChannelSinkProvider : IServerChannelSinkProvider
	{
		#region private field
		private IServerChannelSinkProvider _next = null;
		#endregion

		#region constructor
		public BaseServerChannelSinkProvider(){}
		public BaseServerChannelSinkProvider(IDictionary properties, ICollection providerData){}
		#endregion

		#region Implements IServerChannelSinkProvider
		public IServerChannelSink CreateSink(IChannelReceiver channel)
		{
			IServerChannelSink nextSink = null;
			if(_next != null)
				nextSink = _next.CreateSink(channel);

			return new BaseServerChannelSink(nextSink);
		}

		public void GetChannelData(IChannelDataStore store)
		{
			_next.GetChannelData(store);
		}

		public IServerChannelSinkProvider Next
		{
			get{return _next;}
			set{_next = value;}
		}
		#endregion
	}
	#endregion
}