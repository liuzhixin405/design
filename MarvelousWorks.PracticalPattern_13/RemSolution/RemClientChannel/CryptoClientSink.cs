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
	#region CryptoClientChannelSink
	internal class CryptoClientChannelSink : BaseChannelObjectWithProperties, IClientChannelSink
	{
		#region private field
		private IClientChannelSink _nextSink = null;
		#endregion

		#region constructor
		public CryptoClientChannelSink() : base(){}
		public CryptoClientChannelSink(IClientChannelSink nextSink) : base()
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
			#region crypto request stream
			requestStream = CryptoHelper.CryptoStream(ref requestStream);
			#endregion

			_nextSink.ProcessMessage(msg, requestHeaders, requestStream, out responseHeaders, out responseStream);

			#region decrypt response stream

				//throw new Exception("Client Side : response stream header checksum error");
			#endregion

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
			#region Check response stream hash
			string hash = headers[HashHelper.C_HASH_ITEM] as string;
			//Debug.WriteLine("Client Side : response stream hash is " + hash);
			bool check = HashHelper.CheckHash(ref stream, hash);
			if(!check)
				throw new Exception("Client Side : response stream header checksum error");
			#endregion

			stack.AsyncProcessResponse(headers, stream);
		}

		public void AsyncProcessRequest(
			IClientChannelSinkStack stack,
			IMessage msg,
			ITransportHeaders headers,
			Stream stream
			)
		{
			#region Add hash to stream header
			string hash = HashHelper.GetHash(ref stream);
			headers[HashHelper.C_HASH_ITEM] = hash;
			//Debug.WriteLine("Client Side : client request stream hash is " + hash);
			#endregion

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

	#region CryptoClientChannelSinkProvider
	internal class CryptoClientChannelSinkProvider : IClientChannelSinkProvider
	{
		#region private field
		private IClientChannelSinkProvider _next = null;
		#endregion

		#region constrcutor
		public CryptoClientChannelSinkProvider() {}
		public CryptoClientChannelSinkProvider(IDictionary properties, ICollection providerData)
		{
		}
		#endregion

		#region Imeplments IClientChannelSinkProvider
		public IClientChannelSink CreateSink(IChannelSender channel, string url, object channelData)
		{
			if(_next == null)
				return null;

			IClientChannelSink nextSink = _next.CreateSink(channel, url, channelData);
			return new CryptoClientChannelSink(nextSink);
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
