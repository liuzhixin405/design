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
    /// 对所有业务对象的基本抽象
    /// </summary>
    public interface IBusinessObject
    {
    }

    
    /// <summary>
    /// 通过配置和属性反射实现的Mapper抽象类型
    /// </summary>
    public class DataMapper<T>
        where T : IBusinessObject
    {
        /// <summary>
        /// 需要访问的映射配置文件
        /// </summary>
        private const string MapConfigFile = "Mapping.xml";

        /// <summary>
        /// 配置文件中定义好的配置属性
        /// </summary>
        private const string SourceItem = "source";
        private const string TargetItem = "target";

        /// <summary>
        /// 配置文件定义了、且目标类型实例包括的 O/R 映射关系
        /// </summary>
        private IDictionary<string, string> mappedFieldList;

        public DataMapper(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("name");

            IDictionary<string, string> map = LoadMappingsFromConfig(name);
            mappedFieldList = GetMappedPropertyList(map);
        }

        /// <summary>
        /// 根据DataRow的内容更新目标类型实例的属性值
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
        /// 根据配置文件的内容，获得名称映射关系
        /// </summary>
        private IDictionary<string, string> LoadMappingsFromConfig(string name)
        {
            #region 通过XPath定位当前业务实体的配置部分
            string xPath = string.Format("/mappings/entity[@name=\"{0}\"]/map", name);
            IDictionary<string, string> map = new Dictionary<string, string>();
            XPathDocument doc = new XPathDocument(MapConfigFile);
            XPathNavigator navigator = doc.CreateNavigator();
            XPathNodeIterator iterator = navigator.Select(xPath);
            #endregion

            #region 加载每个配置关系
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
        /// 筛选某个类型其属性中实际定义了映射关系的字段列表
        /// </summary>
        /// <returns></returns>
        private IDictionary<string, string> GetMappedPropertyList(
            IDictionary<string, string> map)
        {
            /// 遍历目标实例
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
