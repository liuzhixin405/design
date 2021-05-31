using System;
using System.Collections.Generic;
using System.Xml;
using MarvellousWorks.PracticalPattern.Common;
namespace MarvellousWorks.PracticalPattern.AdapterPattern.XML
{
    public abstract class XsltAdapterBase
    {
        protected string xslt;
        public virtual XmlDocument Transform(XmlDocument source)
        {
            return XmlHelper.Transform(xslt, source);
        }
    }

    public class OrderAdapter : XsltAdapterBase
    {
        public OrderAdapter() { base.xslt = "Order.xslt"; }
    }
}
