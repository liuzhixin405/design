using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Diagnostics;
namespace MarvellousWorks.PracticalPattern.PageControllerPattern
{
    public class BasePage : Page
    {
        protected virtual void PageLoadEvent(object sender, System.EventArgs e)
        {
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                System.Diagnostics.Trace.WriteLine(Context.User.Identity.Name);
                System.Diagnostics.Trace.WriteLine(Context.Request.Url);
                PageLoadEvent(sender, e);
            }
        }

        override protected void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);
        }

        private void InitializeComponent()
        {
            this.Load += new System.EventHandler(this.Page_Load);
        }
    }
}
