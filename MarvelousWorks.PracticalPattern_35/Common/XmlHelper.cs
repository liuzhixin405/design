using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Xsl;
using System.Collections.Generic;
using System.IO;
namespace MarvellousWorks.PracticalPattern.Common
{
    /// <summary>
    /// 完成一般XML操作的工具类型
    /// </summary>
    public static class XmlHelper
    {
        /// <summary>
        /// 保存所有被加载并编译的 XSLT 实例缓冲
        /// </summary>
        private static Dictionary<string, XslCompiledTransform> transforms =
            new Dictionary<string, XslCompiledTransform>();

        /// <summary>
        /// 根据 XSLT 的定义完成 XML 文件的转换
        /// </summary>
        /// <param name="xsltFile"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public static XmlDocument Transform(string xsltFile, XmlDocument source)
        {
            XslCompiledTransform tranform = GetTransform(xsltFile);
            using (MemoryStream stream = new MemoryStream())
            {
                tranform.Transform(source, null, stream);
                stream.Position = 0;
                XmlDocument target = new XmlDocument();
                target.Load(stream);
                return target;
            }
        }

        private static XslCompiledTransform GetTransform(string xsltFile)
        {
            // 根据缓冲情况获取 XSLT 实例
            XslCompiledTransform transform;
            if (!transforms.TryGetValue(xsltFile, out transform))
            {
                transform = new XslCompiledTransform();
                transform.Load(xsltFile);
                transforms.Add(xsltFile, transform);
            }
            return transform;
        }

        /// <summary>
        /// 基于 XPath 获取指定XML节点
        /// </summary>
        /// <param name="document"></param>
        /// <param name="xpath"></param>
        /// <returns></returns>
        public static XmlNode GetXmlNode(XmlDocument document, string xpath)
        {
            return document.SelectSingleNode(xpath);
        }

        /// <summary>
        /// 基于 XPath 获取一组 XML 节点。
        /// </summary>
        /// <param name="document"></param>
        /// <param name="xpath"></param>
        /// <returns></returns>
        public static XmlNodeList GetXmlNodeList(XmlDocument document, string xpath)
        {
            return document.SelectNodes(xpath);
        }
    }
}
