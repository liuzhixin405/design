using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
namespace MarvellousWorks.PracticalPattern.WebServiceInterceptingFilter.WebSite
{
    /// <summary>
    /// 用来保存Intercepting filter获取的信息
    /// </summary>
    static class InterceptionDictionary 
    {
        public static readonly IDictionary<string, string> Registry =
            new Dictionary<string, string>();
    }

    /// <summary>
    /// 抽象Interceptering filter
    /// </summary>
    public abstract class HttpModuleBase : IHttpModule
    {
        /// <summary>
        /// 初始化过程中,完成Interceptering Filter与实际消息处理事件的预定
        /// </summary>
        /// <param name="context"></param>
        public virtual void Init(HttpApplication context)
        {
            context.BeginRequest += Application_BeginRequest;
        }

        /// <summary>
        /// 交给每个具体的Interceptering filter定义自己拦截操作的方法
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public abstract void Application_BeginRequest(object source, EventArgs e);

        public virtual void Dispose() { }

        /// <summary>
        /// Helper Method
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected HttpContext GetContext(object source)
        {
            return ((HttpApplication)source).Context;
        }
    }

    /// <summary>
    /// 自定义的Interceptering filter
    /// </summary>
    public class IPAddressModule : HttpModuleBase
    {
        public override void Application_BeginRequest(object source, EventArgs e)
        {
            HttpContext context = GetContext(source);
            InterceptionDictionary.Registry.Add("IP", context.Request.UserHostAddress);
            Trace.WriteLine(context.Request.UserHostAddress);
        }
    }

    public class UrlModule : HttpModuleBase
    {
        public override void Application_BeginRequest(object source, EventArgs e)
        {
            HttpContext context = GetContext(source);
            InterceptionDictionary.Registry.Add("URL", context.Request.Url.ToString());
            Trace.WriteLine(context.Request.Url.ToString());
        }
    }
}
