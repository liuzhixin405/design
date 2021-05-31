#region using
using System;
using System.IO;
#endregion

namespace Test.Rem.Common
{
	public class StreamHelper
	{
		#region constructor
		private StreamHelper(){}
		#endregion

		#region const
		private const int c_BufferSize = 2048;
		#endregion

		#region public static method
		public static Stream GetStreamCopy(ref Stream stream)
		{
			Stream streamCopy = new MemoryStream();
			byte[] buff = new byte[c_BufferSize];
			int readCount;

			do
			{
				readCount = stream.Read(buff, 0, c_BufferSize);
				if(readCount > 0)
					streamCopy.Write(buff, 0, readCount);
			}while(readCount > 0);

			//stream.Close();
			streamCopy.Position = 0;
			return streamCopy;
		}
		#endregion
	}
}
