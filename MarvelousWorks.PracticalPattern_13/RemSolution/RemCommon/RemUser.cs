#region using
using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
#endregion

namespace Test.Rem.Common
{
	#region ChannelSinkCallContext
	[Serializable]
	public class ChannelSinkCallContext : ISerializable
	{
		#region private field
		private string _userName = String.Empty;
		#endregion

		#region constructor
		public ChannelSinkCallContext(){}

		public ChannelSinkCallContext(SerializationInfo info, StreamingContext context) 
		{
			_userName = (string)info.GetValue("_userName", typeof(string));
		}		
		#endregion

		#region implements interface ISerializable

		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("_userName", _userName);
		}

		#endregion

		#region public property
		public string UserName
		{
			get
			{
				return _userName;
			}
			set
			{
				_userName = value;
			}
		}
		#endregion

		#region public static field
		public static string ChannelSinkCallContextHeader
		{
			get
			{
				return "ChannelSinkCallContext";
			}
		}
		#endregion

		#region public static method
		public static string SerializeCallContextToString(ChannelSinkCallContext context)
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			MemoryStream memoryStream = new MemoryStream();
			binaryFormatter.Serialize(memoryStream, context);

			// convert the stream into a string
			Byte[] arrGraph = memoryStream.ToArray();
			return Convert.ToBase64String(arrGraph);
		}

		public static ChannelSinkCallContext DeserializeCallContextFromString(string context)
		{
			Byte[] arrGraph = Convert.FromBase64String(context);
			MemoryStream memoryStream = new MemoryStream(arrGraph);

			// deserialize the stream into an object graph
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			return (ChannelSinkCallContext)binaryFormatter.Deserialize(memoryStream);
		}
		#endregion
	}
	#endregion
}
