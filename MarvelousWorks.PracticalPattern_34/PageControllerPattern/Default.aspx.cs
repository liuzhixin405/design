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
using MarvellousWorks.PracticalPattern.PageControllerPattern;

namespace PageControllerPattern
{
    public partial class _Default : BasePage
    {
        protected override void PageLoadEvent(object sender, EventArgs e)
        {
            title.Text = "Default concrete page";
            base.PageLoadEvent(sender, e);
        }
    }
}
