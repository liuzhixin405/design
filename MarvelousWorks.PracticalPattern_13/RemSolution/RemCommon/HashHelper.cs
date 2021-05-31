#region using
using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Diagnostics;
#endregion

namespace Test.Rem.Common
{
	#region HashHelper
	public class HashHelper
	{
		#region constructor
		private HashHelper(){}
		static HashHelper()
		{
			sha = new SHA1CryptoServiceProvider();
		}
		#endregion

		#region const
		private const int c_BufferSize = 1024;

		public const string C_HASH_ITEM = "HashHeader";
		#endregion

		#region private static field
		private static SHA1 sha = null;
		#endregion

		#region static helper method
		private static byte[] PadByteArray(byte[] array1, byte[] array2)
		{
			#region validate input parameter
			if((array1 == null) && (array2 == null))
				return null;
			if(array1 == null)
				return array2;
			if(array2 == null)
				return array1;
			#endregion

			byte[] result = new byte[array1.Length + array2.Length];
			for(int i=0; i<array1.Length; i++)
				result[i] = array1[i];
			for(int i=0; i<array2.Length; i++)
				result[i + array1.Length] = array2[i];

			return result;
		}
		#endregion

		#region public static method
		#region Stream hash method
		public static string GetHash(ref Stream stream)
		{

			//Validate input parameter
			if(stream == null)
				return "";

			if(!stream.CanSeek)
				stream = StreamHelper.GetStreamCopy(ref stream);

			#region merge stream by hash fragment
			long currPosition = stream.Position;

			byte[] result = new byte[c_BufferSize];
			byte[] buff = new byte[c_BufferSize];
			int len = stream.Read(buff, 0, c_BufferSize);
			while(len > 0)
			{
				result = sha.ComputeHash(PadByteArray(result, buff));
				len = stream.Read(buff, 0, c_BufferSize);
			}

			stream.Position = currPosition;
			#endregion

			return Convert.ToBase64String(result);
		}

		public static bool CheckHash(ref Stream stream, string hash)
		{
			//validate input parameter
			if(hash == null) 
				return false;

			string newHash = GetHash(ref stream);
			return (newHash == hash) ? true : false;
		}
		#endregion

		#region string hash method
		public static string GetHash(string str)
		{
			Encoding unicode = Encoding.Unicode;
			byte[] array = unicode.GetBytes(str);
			byte[] result = sha.ComputeHash(array);

			return Convert.ToBase64String(result);
		}

		public static bool CheckHash(string str, string hash)
		{
			string newHash = GetHash(str);
			return (newHash == hash) ? true : false;
		}
		#endregion
		#endregion
	}
	#endregion
}
