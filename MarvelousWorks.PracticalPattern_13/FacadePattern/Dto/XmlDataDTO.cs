using System;
using System.Collections.Generic;
using System.Xml;
using System.Data;
using System.Data.Common;
namespace MarvellousWorks.PracticalPattern.FacadePattern.Dto
{
    /// <summary>
    /// 返回结果为 XmlDocument 方式的 DTO 接口定义
    /// </summary>
    public interface IXmlDataDto
    {
        XmlDocument GetCurrency(string sql);
        IDataFacade Facade { set;}
    }

    public class XmlDataDto : IXmlDataDto
    {
        private IDataFacade facade;

        /// <summary>
        /// 为DTO对象指定需要打包的对象
        /// </summary>
        public IDataFacade Facade { set { this.facade = value; } }

        /// <summary>
        /// 调用外观对象，并将请求结果以自定义的XML序列化方式打包；
        /// </summary>
        /// <param name="facade"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public XmlDocument GetCurrency(string sql)
        {
            if (facade == null) throw new ArgumentNullException("facade");
            if (string.IsNullOrEmpty(sql)) throw new ArgumentNullException("sql");
            DbDataReader reader = facade.ExecuteQuery(sql);
            if (!reader.HasRows) return null;
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("root");
            doc.AppendChild(root);
            while (reader.Read())
            {
                XmlElement element = doc.CreateElement("currency");
                element.SetAttribute("code", reader.GetString(0));  // currency code
                element.SetAttribute("name", reader.GetString(1));  // currency code
                root.AppendChild(element);
            }
            return doc;    
        }
    }
}
