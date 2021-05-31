using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;
using MarvellousWorks.PracticalPattern.Common;
using MarvellousWorks.PracticalPattern.CompositePattern.Test;
using MarvellousWorks.PracticalPattern.CompositePattern.Iterating;
namespace MarvellousWorks.PracticalPattern.CompositePattern.Test.Xml
{
    [TestClass]
    public class TestXmlComposite
    {
        class Department : Composite{}
        class Corporate : Composite
        {
            private ComponentFactory factory = new ComponentFactory();
            private XmlDocument GetXmlDocument()
            {
                // 为了使用方便，这里把XML文件的内容保存在资源文件里
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(Resource.CorporateData);
                return doc;
            }

            public IList<Department> GetDepartments()
            {
                string xpath = "/corporate/department";
                XmlNodeList list = XmlHelper.GetXmlNodeList(GetXmlDocument(), xpath);
                if ((list == null) || (list.Count == 0)) return null;
                IList<Department> departments = new List<Department>();
                foreach (XmlNode node in list)
                {
                    string name = node.Attributes["name"].Value;
                    departments.Add((Department)factory.Create<Department>(name));
                }
                return departments;
            }
        }

        [TestMethod]
        public void Test()
        {
            Corporate target = new Corporate();
            IList<Department> departments = target.GetDepartments();
            Assert.AreEqual<int>(2, departments.Count);
            Assert.AreEqual<string>("market", departments[0].Name);
            Assert.AreEqual<string>("sales", departments[1].Name);
        }
    }
}
