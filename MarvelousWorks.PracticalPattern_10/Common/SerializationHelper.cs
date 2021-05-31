using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Remoting.Messaging;
namespace MarvellousWorks.PracticalPattern.Common
{
    public enum FormatterType
    {
        /// <summary>
        /// SOAP消息格式编码
        /// </summary>
        Soap,

        /// <summary>
        /// 二进制消息格式编码
        /// </summary>
        Binary
    }

    public static class SerializationHelper
    {
        private const FormatterType DefaultFormatterType = FormatterType.Binary;

        /// <summary>
        /// 按照串行化的编码要求，生成对应的编码器。
        /// </summary>
        /// <param name="formatterType"></param>
        /// <returns></returns>
        private static IRemotingFormatter GetFormatter(FormatterType formatterType)
        {
            switch (formatterType)
            {
                case FormatterType.Binary: return new BinaryFormatter();
                case FormatterType.Soap: return new SoapFormatter();
            }
            throw new NotSupportedException();
        }

        /// <summary>
        /// 把对象序列化转换为字符串
        /// </summary>
        /// <param name="graph">可串行化对象实例</param>
        /// <param name="formatterType">消息格式编码类型（Soap或Binary型）</param>
        /// <returns>串行化转化结果</returns>
        /// <remarks>调用BinaryFormatter或SoapFormatter的Serialize方法实现主要转换过程。
        /// </remarks>    
        public static string SerializeObjectToString(object graph, FormatterType formatterType)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                IRemotingFormatter formatter = GetFormatter(formatterType);
                formatter.Serialize(memoryStream, graph);
                Byte[] arrGraph = memoryStream.ToArray();
                return Convert.ToBase64String(arrGraph);
            }
        }
        public static string SerializeObjectToString(object graph)
        {
            return SerializeObjectToString(graph, DefaultFormatterType);
        }

        /// <summary>
        /// 把已序列化为字符串类型的对象反序列化为指定的类型
        /// </summary>
        /// <param name="serializedGraph">已序列化为字符串类型的对象</param>
        /// <param name="formatterType">消息格式编码类型（Soap或Binary型）</param>
        /// <typeparam name="T">对象转换后的类型</typeparam>
        /// <returns>串行化转化结果</returns>
        /// <remarks>调用BinaryFormatter或SoapFormatter的Deserialize方法实现主要转换过程。
        /// </remarks>
        public static T DeserializeStringToObject<T>(string graph, FormatterType formatterType)
        {
            Byte[] arrGraph = Convert.FromBase64String(graph);
            using (MemoryStream memoryStream = new MemoryStream(arrGraph))
            {
                IRemotingFormatter formatter = GetFormatter(formatterType);
                return (T)formatter.Deserialize(memoryStream);
            }
        }

        public static T DeserializeStringToObject<T>(string graph)
        {
            return DeserializeStringToObject<T>(graph, DefaultFormatterType);
        }
    }
}
