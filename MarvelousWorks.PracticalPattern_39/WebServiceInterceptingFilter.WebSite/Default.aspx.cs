using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace MarvellousWorks.PracticalPattern.WebServiceInterceptingFilter.WebSite
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Assert.AreEqual<string>(Request.UserHostAddress, 
                InterceptionDictionary.Registry["IP"]);
            Assert.AreEqual<string>(Request.Url.ToString(), 
                InterceptionDictionary.Registry["URL"]);
        }
    }
}
