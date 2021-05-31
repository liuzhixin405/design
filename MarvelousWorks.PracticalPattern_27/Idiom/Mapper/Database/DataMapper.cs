using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using System.Xml.XPath;
using System.Reflection;
using System.Data;
namespace MarvellousWorks.PracticalPattern.Idiom.Mapper.Database
{
    /// <summary>
    /// ������ҵ�����Ļ�������
    /// </summary>
    public interface IBusinessObject
    {
    }

    
    /// <summary>
    /// ͨ�����ú����Է���ʵ�ֵ�Mapper��������
    /// </summary>
    public class DataMapper<T>
        where T : IBusinessObject
    {
        /// <summary>
        /// ��Ҫ���ʵ�ӳ�������ļ�
        /// </summary>
        private const string MapConfigFile = "Mapping.xml";

        /// <summary>
        /// �����ļ��ж���õ���������
        /// </summary>
        private const string SourceItem = "source";
        private const string TargetItem = "target";

        /// <summary>
        /// �����ļ������ˡ���Ŀ������ʵ�������� O/R ӳ���ϵ
        /// </summary>
        private IDictionary<string, string> mappedFieldList;

        public DataMapper(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("name");

            IDictionary<string, string> map = LoadMappingsFromConfig(name);
            mappedFieldList = GetMappedPropertyList(map);
        }

        /// <summary>
        /// ����DataRow�����ݸ���Ŀ������ʵ��������ֵ
        /// </summary>
        /// <param name="target"></param>
        /// <param name="row"></param>
        /// <param name="fieldName"></param>
        public void SetPropertyValues(object target, DataRow row)
        {
            if (mappedFieldList == null) return;
            if (target == null) throw new ArgumentNullException("target");
            if (row == null) throw new ArgumentNullException("row");

            foreach (KeyValuePair<string, string> pair in mappedFieldList)
            {
                if(row[pair.Key] != DBNull.Value)
                    typeof(T).GetProperty(pair.Value).SetValue(target, row[pair.Key], null);
            }
        }

        #region Helper Methods
        /// <summary>
        /// ���������ļ������ݣ��������ӳ���ϵ
        /// </summary>
        private IDictionary<string, string> LoadMappingsFromConfig(string name)
        {
            #region ͨ��XPath��λ��ǰҵ��ʵ������ò���
            string xPath = string.Format("/mappings/entity[@name=\"{0}\"]/map", name);
            IDictionary<string, string> map = new Dictionary<string, string>();
            XPathDocument doc = new XPathDocument(MapConfigFile);
            XPathNavigator navigator = doc.CreateNavigator();
            XPathNodeIterator iterator = navigator.Select(xPath);
            #endregion

            #region ����ÿ�����ù�ϵ
            while (iterator.MoveNext())
            {
                string source = iterator.Current.GetAttribute(SourceItem, string.Empty);
                string target = iterator.Current.GetAttribute(TargetItem, string.Empty);
                map.Add(target, source);
            }
            #endregion

            return (map.Count == 0) ? null : map;
        }

        /// <summary>
        /// ɸѡĳ��������������ʵ�ʶ�����ӳ���ϵ���ֶ��б�
        /// </summary>
        /// <returns></returns>
        private IDictionary<string, string> GetMappedPropertyList(
            IDictionary<string, string> map)
        {
            /// ����Ŀ��ʵ��
            PropertyInfo[] properties = typeof(T).GetProperties();
            if ((properties == null) || (properties.Length == 0)) return null;
            IDictionary<string, string> list = new Dictionary<string, string>();
            foreach (PropertyInfo info in properties)
            {
                string source;
                if (!map.TryGetValue(info.Name, out source))
                    continue;
                list.Add(source, info.Name);
            }
            return (list.Count == 0) ? null : list;
        }
        #endregion
    }
}
