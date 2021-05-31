#region Usings
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

using MarvellousWorks.PracticalPattern.Common;
#endregion
namespace Common.Test.Web
{
    public partial class GenericContextTest : System.Web.UI.Page
    {
        private const string Key = "id";
        private GenericContext context = new GenericContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            context[Key] = Guid.NewGuid().ToString();

            step1.Text = context[Key] as string;
            step2.Text = context[Key] as string;
            step3.Text = context[Key] as string;
        }
    }
}
