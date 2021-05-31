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
	#region HashServerChannelSink
	internal class HashServerChannelSink : BaseChannelObjectWithProperties, IServerChannelSink
	{
		#region private field
		private IServerChannelSink _nextSink = null;
		#endregion

		#region constructor
		public HashServerChannelSink() : base(){}
		public HashServerChannelSink(IServerChannelSink nextSink) :base()
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

			#region Check request stream header hash
			string hash = requestHeaders[HashHelper.C_HASH_ITEM] as String;
			//Debug.WriteLine("Server Side : request stream hash is " + hash);
			bool check = HashHelper.CheckHash(ref requestStream, hash);
			if(!check)
				throw new Exception("Server Side : request stream header checksum error");
			#endregion

			ServerProcessing result = _nextSink.ProcessMessage(stack, requestMsg, requestHeaders, requestStream, out responseMsg, out responseHeaders, out responseStream);

			#region Add hash to response stream heaer
			hash = HashHelper.GetHash(ref responseStream);
			responseHeaders[HashHelper.C_HASH_ITEM] = hash;
			//Debug.WriteLine("Server Side : response stream hash is " + hash);
			#endregion

			return result;
		}
		public void AsyncProcessResponse(
			IServerResponseChannelSinkStack stack,
			object state,
			IMessage msg,
			ITransportHeaders headers,
			Stream stream)
		{
			#region Add hash to stream header
			string hash = HashHelper.GetHash(ref stream);
			headers[HashHelper.C_HASH_ITEM] = hash;
			//Debug.WriteLine("Server Side : server response stream hash is " + hash);
			#endregion

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

	#region HashServerChannelSinkProvider
	internal class HashServerChannelSinkProvider : IServerChannelSinkProvider
	{
		#region private field
		private IServerChannelSinkProvider _next = null;
		#endregion

		#region constructor
		public HashServerChannelSinkProvider(){}
		public HashServerChannelSinkProvider(IDictionary properties, ICollection providerData){}
		#endregion

		#region Implements IServerChannelSinkProvider
		public IServerChannelSink CreateSink(IChannelReceiver channel)
		{
			IServerChannelSink nextSink = null;
			if(_next != null)
				nextSink = _next.CreateSink(channel);

			return new HashServerChannelSink(nextSink);
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