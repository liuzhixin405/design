using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.ObjectModel;
namespace MarvellousWorks.PracticalPattern.PrototypePattern.Mixed
{
    /// <summary>
    /// ��ȫ��Ϣ������
    /// </summary>
    /// <remarks>
    ///     Ϊ��ͬʱ����Binary���ú�Soap���õ���Ҫ����ȫ���Ƶ�L���л�����
    /// </remarks>
    [XmlRoot("securityContext")]
    [Serializable]
    public class SecurityContext : 
        IXmlSerializable,   // ���XML���л�
        ISerializable       // �����ͨ�����л�
    {
        #region Protected Fields & Constantants

        //// <summary>
        /// Xml���л�������ÿ����key / value�����element����
        /// </summary>
        protected const string KeyValuePairItem = "item";

        /**//// <summary>
        /// Xml���л�������key���ֵ�element����
        /// </summary>
        protected const string KeyItem = "key";

        /**//// <summary>
        /// Xml���л�������value���ֵ�element����
        /// </summary>
        protected const string ValueItem = "value";

        /**//// <summary>
        /// ��ͨ���л������� keys ��
        /// </summary>
        protected const string KeysItem = "keys";

        /**//// <summary>
        /// ��ͨ���л������� values ��
        /// </summary>
        protected const string ValuesItem = "values";

        //// <summary>
        /// ����
        /// </summary>
        [NonSerialized]
        protected IDictionary<string, string> dictionary;

        #endregion

        #region Constructors

        /**//// <summary>
        /// ���������л��Ĺ���
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
        /// ����
        /// </summary>
        public SecurityContext()
        {
            dictionary = CreateDictionary();
        }

        #endregion


        /**//// <summary>
        /// ����Context������
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <remarks>����ϣ�������Ͳ�������׳��쳣�������ṩ��keyֵΪ�մ�</remarks>
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
        /// ����Schema
        /// </summary>
        /// <returns></returns>
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        //// <summary>
        /// ���л�֮���������
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
        /// ���л�������XML
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
        /// ��ͨ���л��Ĵ���
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
