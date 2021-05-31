using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;
namespace MarvellousWorks.PracticalPattern.Common
{
    public static class CryptoHelper
    {
        #region Private field
        /// <summary>
        /// Hash algorithm
        /// </summary>
        private static SHA1 sha;

        /// <summary>
        /// Crypto transformer of encryption
        /// </summary>
        private static ICryptoTransform et;

        /// <summary>
        /// Crypto transformer of decryption
        /// </summary>
        private static ICryptoTransform dt;
        #endregion

        #region Constructor
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <remarks>无参数的构造函数，用默认的方式初始化各个属性。
        /// </remarks>
        static CryptoHelper()
        {
            CryptoHelper.sha = new SHA1CryptoServiceProvider();
            DESCryptoServiceProvider cryptoService = new DESCryptoServiceProvider();
            byte[] cryptoKey = { 136, 183, 142, 217, 175, 71, 90, 239 };
            byte[] cryptoIV = { 227, 105, 5, 40, 162, 158, 143, 156 };


            cryptoService.Key = cryptoKey;
            cryptoService.IV = cryptoIV;

            CryptoHelper.et = cryptoService.CreateEncryptor();
            CryptoHelper.dt = cryptoService.CreateDecryptor();
        }
        #endregion

        #region hash / comparehash
        /// <overrides>
        /// Computes the hash value of plain text using the given hash provider instance
        /// </overrides>
        /// <summary>
        /// Computes the hash value of plain text using the given hash provider instance
        /// </summary>
        /// <param name="plaintext">The input for which to compute the hash.</param>
        /// <returns>The computed hash code.</returns>
        private static byte[] CreateHash(byte[] plaintext)
        {
            return CryptoHelper.sha.ComputeHash(plaintext);
        }

        /// <summary>
        /// 为纯文本字符串计算哈希值
        /// </summary>
        /// <param name="plaintext">需要计算哈希值的纯文本字符串</param>
        /// <returns>计算出的哈希值</returns>
        /// <remarks>
        /// 为纯文本字符串计算哈希值。
        /// </remarks>
        public static string CreateHash(string plaintext)
        {
            byte[] plainTextBytes = UnicodeEncoding.Unicode.GetBytes(plaintext);
            byte[] resultBytes = CreateHash(plainTextBytes);

            return Convert.ToBase64String(resultBytes);
        }

        /// <overrides>
        /// Compares plain text input with a computed hash using the given hash provider instance.
        /// </overrides>
        /// <summary>
        /// Compares plain text input with a computed hash using the given hash provider instance.
        /// </summary>
        /// <remarks>
        /// Use this method to compare hash values. Since hashes may contain a random "salt" value, two seperately generated
        /// hashes of the same plain text may result in different values. 
        /// </remarks>
        /// <param name="plaintext">The input for which you want to compare the hash to.</param>
        /// <param name="hashedText">The hash value for which you want to compare the input to.</param>
        /// <returns><c>true</c> if plainText hashed is equal to the hashedText. Otherwise, <c>false</c>.</returns>
        private static bool HashCheck(byte[] plaintext, byte[] hashedText)
        {
            if ((hashedText == null) || (hashedText.Length <= 0))
                return false;

            byte[] hashedResult = CryptoHelper.sha.ComputeHash(plaintext);
            if (hashedText.Length != hashedResult.Length)
                return false;

            for (int i = 0; i < hashedResult.Length; i++)
            {
                if (hashedText[i] != hashedResult[i])
                    return false;
            }

            return true;
        }

        /// <summary>
        /// 比较由纯文本串计算出的哈希值与给定的哈希值是否一致。
        /// </summary>
        /// <param name="plaintext">输入需要进行哈希比较的字符串</param>
        /// <param name="hashedText">哈希串</param>
        /// <returns><c>true</c> 如果纯文本哈希值与给定的哈希值相等，否则返回<c>false</c>.</returns>
        /// <remarks>
        /// 运用这个方法来比较由纯文本串计算的哈希值和给定的哈希值是否一致。
        /// </remarks>
        public static bool HashCheck(string plaintext, string hashedText)
        {
            byte[] plainTextBytes = UnicodeEncoding.Unicode.GetBytes(plaintext);
            byte[] hashedTextBytes = Convert.FromBase64String(hashedText);

            bool result = HashCheck(plainTextBytes, hashedTextBytes);

            return result;
        }
        #endregion

        #region nvative key encrypt / decrypt

        /// <summary>
        /// 对字符串的解密处理
        /// </summary>
        /// <param name="source">需要解密的字符串</param>
        /// <returns>解密后的字符串</returns>
        /// <remarks>对字符串的解密处理
        /// </remarks>
        public static string Decrypt(string source)
        {
            byte[] buff = Convert.FromBase64String(source);
            using (MemoryStream mem = new MemoryStream())
            {
                using (CryptoStream stream = new CryptoStream(mem, CryptoHelper.dt, CryptoStreamMode.Write))
                {
                    stream.Write(buff, 0, buff.Length);
                    stream.Close();
                }
                return Encoding.Unicode.GetString(mem.ToArray());
            }
        }

        /// <summary>
        /// 对字符串的加密处理
        /// </summary>
        /// <param name="source">需要加密的字符串</param>
        /// <returns>加密后的字符串</returns>
        /// <remarks>对字符串的加密处理
        /// </remarks>
        public static string Encrypt(string source)
        {
            byte[] buff = Encoding.Unicode.GetBytes(source);

            MemoryStream mem = new MemoryStream();
            CryptoStream stream = new CryptoStream(mem, CryptoHelper.et, CryptoStreamMode.Write);
            stream.Write(buff, 0, buff.Length);
            stream.FlushFinalBlock();
            stream.Clear();

            return Convert.ToBase64String(mem.ToArray());
        }
        #endregion

        #region encode / decode
        private const string CodePageName = "utf-32";

        /// <summary>
        /// 将字符串进行Base64编码
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string Encode(string source)
        {
            byte[] buffer = Encoding.GetEncoding(CodePageName).GetBytes(source);
            return Convert.ToBase64String(buffer);
        }

        /// <summary>
        /// 将字符串进行Base64解码
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string Decode(string source)
        {
            byte[] buffer = Convert.FromBase64String(source);
            return Encoding.GetEncoding(CodePageName).GetString(buffer);
        }
        #endregion
    }
}
