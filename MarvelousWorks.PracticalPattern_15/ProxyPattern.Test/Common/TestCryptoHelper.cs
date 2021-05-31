using System;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.Common;
namespace ProxyPattern.Test.Common
{
    [TestClass]
    public class TestCryptoHelper
    {
        [TestMethod]
        public void TestEncryptAndDecrypt()
        {
            string plainText = "Hello";
            string cryptText = CryptoHelper.Encrypt(plainText);
            Assert.AreNotEqual<string>(plainText, cryptText);
            string decrpytText = CryptoHelper.Decrypt(cryptText);
            Assert.AreEqual<string>(plainText, decrpytText);
            Trace.WriteLine(plainText);
            Trace.WriteLine(cryptText);
            Trace.WriteLine(decrpytText);
        }

        [TestMethod]
        public void TestEncodeAndDecode()
        {
            string source = "Hello";
            string target = CryptoHelper.Encode(source);
            Assert.AreNotEqual<string>(source, target);
            string decode = CryptoHelper.Decode(target);
            Assert.AreEqual<string>(source, decode);
            Trace.WriteLine(source);
            Trace.WriteLine(target);
            Trace.WriteLine(decode);
        }
    }
}
    