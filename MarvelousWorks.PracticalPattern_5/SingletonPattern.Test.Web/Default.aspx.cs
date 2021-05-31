using System;
using System.Web;
using MarvellousWorks.PracticalPattern.SingletonPattern.WebContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace SingletonPattern.Test.Web
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Singleton s1 = Singleton.Instance;
            Singleton s2 = Singleton.Instance;
            // 确认获得的Singleton实例引用确实已经被实例化了
            Assert.IsNotNull(s1);
            Assert.IsNotNull(s2);
            // 确认两个引用调用的是同一个Singleton实例
            Assert.AreEqual<int>(s1.GetHashCode(), s2.GetHashCode());
            // 显示出当前Singleton实例的标识，用于比较与其他
            // HttpContext环境下的Singleton实例其实是不同的实例
            instanceHashCode.Text = s1.GetHashCode().ToString();
        }
    }
}
