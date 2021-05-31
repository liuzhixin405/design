using System;
using System.Collections.Generic;
using System.Text;
using MarvellousWorks.PracticalPattern.Common;
using MarvellousWorks.PracticalPattern.PrototypePattern.Mixed;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.Serialization;
namespace MarvellousWorks.PracticalPattern.PrototypePattern.Test.Mixed
{
    //// <summary>
    /// 测试安全上下文
    /// </summary>
    [TestClass]
    public class SecurityContextFixture
    {
        //// <summary>
        /// Prepare
        /// </summary>
        /// <returns></returns>
        private SecurityContext CreateContext()
        {
            SecurityContext context = new SecurityContext();
            context["hello"] = "world";
            context["1"] = "first";
            return context;
        }

        //// <summary>
        /// 访问SecurityContext
        /// </summary>
        [TestMethod]
        public void TestContextAccess()
        {
            SecurityContext context = CreateContext();

            Assert.AreEqual<string>("world", context["hello"]);
            Assert.AreEqual<string>("first", context["1"]);
            Assert.IsTrue(string.IsNullOrEmpty(context["2"]));

            context["1"] = "First";
            Assert.AreEqual<string>("First", context["1"]);
        }

        //// <summary>
        /// 主要确认是否可以被Binary序列化，尤其是用于远程调用
        /// </summary>
        [TestMethod]
        public void TestBinarySerializeContext()
        {
            // 测试序列化
            SecurityContext temp = CreateContext();
            string tempGraph = SerializationHelper.SerializeObjectToString(temp, FormatterType.Binary);
            SecurityContext context = SerializationHelper.DeserializeStringToObject
                <SecurityContext>(tempGraph, FormatterType.Binary);

            Assert.AreEqual<string>("world", context["hello"]);
            Assert.AreEqual<string>("first", context["1"]);
            Assert.IsTrue(string.IsNullOrEmpty(context["2"]));

            string graph = SerializationHelper.SerializeObjectToString(context, FormatterType.Binary);
            Assert.AreEqual<string>(tempGraph, graph);

            // 测试序列化的结构是两个完全不同的实例
            temp["2"] = "Second";
            Assert.IsTrue(string.IsNullOrEmpty(context["2"]));
            context["2"] = "二";
            Assert.AreNotEqual<string>(context["2"], temp["2"]);
        }

        //// <summary>
        /// 主要确认是否可以被Soap序列化，尤其是用于远程调用
        /// </summary>
        [TestMethod]
        public void TestSoapSerializeContext()
        {
            // 测试序列化
            SecurityContext temp = CreateContext();
            string tempGraph = SerializationHelper.SerializeObjectToString(temp, FormatterType.Soap);
            SecurityContext context = SerializationHelper.DeserializeStringToObject
                <SecurityContext>(tempGraph, FormatterType.Soap);

            Assert.AreEqual<string>("world", context["hello"]);
            Assert.AreEqual<string>("first", context["1"]);
            Assert.IsTrue(string.IsNullOrEmpty(context["2"]));

            string graph = SerializationHelper.SerializeObjectToString(context, FormatterType.Soap);
            Assert.AreEqual<string>(tempGraph, graph);
            byte[] buffer = Convert.FromBase64String(graph);
            string soap = Encoding.Default.GetString(buffer);


            // 测试序列化的结构是两个完全不同的实例
            temp["2"] = "Second";
            Assert.IsTrue(string.IsNullOrEmpty(context["2"]));
            context["2"] = "二";
            Assert.AreNotEqual<string>(context["2"], temp["2"]);
        }
    }
}
