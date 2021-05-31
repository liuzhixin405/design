using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.ObjectModel;
namespace MarvellousWorks.PracticalPattern.PrototypePattern.Mixed
{
    /// <summary>
    /// 安全信息上下文
    /// </summary>
    /// <remarks>
    ///     为了同时满足Binary调用和Soap调用的需要，完全定制的L序列化过程
    /// </remarks>
    [XmlRoot("securityContext")]
    [Serializable]
    public class SecurityContext : 
        IXmlSerializable,   // 针对XML序列化
        ISerializable       // 针对普通的序列化
    {
        #region Protected Fields & Constantants

        //// <summary>
        /// Xml序列化过程中每个“key / value”项的element名称
        /// </summary>
        protected const string KeyValuePairItem = "item";

        /**//// <summary>
        /// Xml序列化过程中key部分的element名称
        /// </summary>
        protected const string KeyItem = "key";

        /**//// <summary>
        /// Xml序列化过程中value部分的element名称
        /// </summary>
        protected const string ValueItem = "value";

        /**//// <summary>
        /// 普通序列化过程中 keys 项
        /// </summary>
        protected const string KeysItem = "keys";

        /**//// <summary>
        /// 普通序列化过程中 values 项
        /// </summary>
        protected const string ValuesItem = "values";

        //// <summary>
        /// 集合
        /// </summary>
        [NonSerialized]
        protected IDictionary<string, string> dictionary;

        #endregion

        #region Constructors

        /**//// <summary>
        /// 服务于序列化的构造
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected SecurityContext(SerializationInfo info, StreamingContext context)
        {
            if (dictionary == null)
                dictionary = CreateDictionary();

            string[] keys = (string[])info.GetValue(KeysItem, typeof(string[]));
            string[] values = (string[])info.GetValue(ValuesItem, typeof(string[]));

            if ((keys == null) || (keys.Length == 0) || (values == null) || 
                (values.Length == 0) || (keys.Length != values.Length))
                return;

            for (int i = 0; i < keys.Length; i++)
                dictionary.Add(keys[i], values[i]);
        }

        //// <summary>
        /// 构造
        /// </summary>
        public SecurityContext()
        {
            dictionary = CreateDictionary();
        }

        #endregion


        /**//// <summary>
        /// 访问Context内容项
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <remarks>设计上，这个类型不会随便抛出异常，除非提供的key值为空串</remarks>
        public virtual string this[string key]
        {
            get
            {
                if (string.IsNullOrEmpty(key))
                    throw new ArgumentNullException("key");

                string value;
                if (dictionary.TryGetValue(key, out value))
                    return value;
                else
                    return string.Empty;
            }
            set
            {
                if (string.IsNullOrEmpty(key))
                    throw new ArgumentNullException("key");

                if (dictionary.ContainsKey(key))
                    dictionary[key] = value;
                else
                    dictionary.Add(key, value);
            }
        }

        #region IXmlSerializable Members

        //// <summary>
        /// 定义Schema
        /// </summary>
        /// <returns></returns>
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        //// <summary>
        /// 序列化之后加载内容
        /// </summary>
        /// <param name="reader"></param>
        public void ReadXml(XmlReader reader)
        {
            XmlSerializer keySerializer = new XmlSerializer(typeof(string));
            XmlSerializer valueSerializer = new XmlSerializer(typeof(string));

            if ((reader == null) || (reader.IsEmptyElement))
                return;

            reader.Read();
            if (dictionary == null)
                dictionary = CreateDictionary();
            else
                dictionary.Clear();

            while (reader.NodeType != XmlNodeType.EndElement)
            {
                reader.ReadStartElement(KeyValuePairItem);
                reader.ReadStartElement(KeyItem);
                string key = (string)keySerializer.Deserialize(reader);
                reader.ReadEndElement();
                reader.ReadStartElement(ValueItem);
                string value = (string)valueSerializer.Deserialize(reader);
                reader.ReadEndElement();
                dictionary.Add(key, value);
                reader.ReadEndElement();
                reader.MoveToContent();
            }
            reader.ReadEndElement();
        }

        //// <summary>
        /// 序列化内容至XML
        /// </summary>
        /// <param name="writer"></param>
        public void WriteXml(XmlWriter writer)
        {
            if ((dictionary == null) || (dictionary.Count == 0))
                return;

            XmlSerializer keySerializer = new XmlSerializer(typeof(string));
            XmlSerializer valueSerializer = new XmlSerializer(typeof(string));

            foreach (string key in dictionary.Keys)
            {
                writer.WriteStartElement(KeyValuePairItem);

                writer.WriteStartElement(KeyItem);
                keySerializer.Serialize(writer, key);
                writer.WriteEndElement();
                writer.WriteStartElement(ValueItem);
                string value = dictionary[key];
                valueSerializer.Serialize(writer, value);
                writer.WriteEndElement();
                writer.WriteEndElement();
            }
        }

        #endregion


        #region ISerializable Members


        //// <summary>
        /// 普通序列化的处理
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if ((dictionary == null) || (dictionary.Count == 0))
            {
                info.AddValue(KeysItem, null, typeof(string[]));
                info.AddValue(ValuesItem, null, typeof(string[]));
                return;
            }

            string[] keys = new string[dictionary.Count];
            string[] values = new string[dictionary.Count];
            dictionary.Keys.CopyTo(keys, 0);
            dictionary.Values.CopyTo(values, 0);

            info.AddValue(KeysItem, keys, typeof(string[]));
            info.AddValue(ValuesItem, values, typeof(string[]));
        }

        #endregion        

        #region Helper Methods

        private IDictionary<string, string> CreateDictionary()
        {
            return new Dictionary<string, string>();
        }

        #endregion
    }
}
