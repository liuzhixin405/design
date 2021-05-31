#region using
using System;
using System.IO;
using System.Security;
using System.Security.Cryptography;
using System.Text;

using System.Diagnostics;
#endregion

namespace Test.Rem.Common
{
	public class CryptoHelper
	{
		#region const
		private const string c_Key = "hello";
		private const string c_IV = "world";

		private const int c_BufferSize = 2048;
		private const int c_KeyLength = 16;
		#endregion

		#region private static field
		private static ICryptoTransform encryptor = null;
		private static ICryptoTransform decryptor = null;
		#endregion

		#region constructor
		private CryptoHelper(){}
		static CryptoHelper()
		{
			Encoding encode = Encoding.Unicode;
			byte[] tempKey = encode.GetBytes(HashHelper.GetHash(c_Key));
			byte[] tempIV = encode.GetBytes(HashHelper.GetHash(c_IV));
			byte[] key = new byte[c_KeyLength];
			byte[] iv = new byte[c_KeyLength];
			for(int i=0; i<c_KeyLength; i++)
			{
				key[i] = tempKey[i];
				iv[i] = tempIV[i];
			}

			RijndaelManaged crypto = new RijndaelManaged();
			encryptor = crypto.CreateEncryptor(key, iv);
			decryptor = crypto.CreateDecryptor(key, iv);
		}
		#endregion

		#region public static method
		public static Stream CryptoStream(ref Stream stream)
		{
			#region Validate input parameter
			if(stream == null)
				return null;
			#endregion

			stream = StreamHelper.GetStreamCopy(ref stream);
			CryptoStream cStream = new CryptoStream(stream, encryptor, CryptoStreamMode.Write);
			StreamWriter writer = new StreamWriter(cStream);
			StreamReader reader = new StreamReader(stream);
			string buff = reader.ReadToEnd();
			writer.WriteLine(buff);
			writer.Close();

			Debug.WriteLine(buff);
			
			Stream result = (Stream)cStream;
			cStream.Close();
			result = StreamHelper.GetStreamCopy(ref result);
			return result;
		}
		#endregion
	}
}
