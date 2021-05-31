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
    /// ��������Intercepting filter��ȡ����Ϣ
    /// </summary>
    static class InterceptionDictionary 
    {
        public static readonly IDictionary<string, string> Registry =
            new Dictionary<string, string>();
    }

    /// <summary>
    /// ����Interceptering filter
    /// </summary>
    public abstract class HttpModuleBase : IHttpModule
    {
        /// <summary>
        /// ��ʼ��������,���Interceptering Filter��ʵ����Ϣ�����¼���Ԥ��
        /// </summary>
        /// <param name="context"></param>
        public virtual void Init(HttpApplication context)
        {
            context.BeginRequest += Application_BeginRequest;
        }

        /// <summary>
        /// ����ÿ�������Interceptering filter�����Լ����ز����ķ���
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
    /// �Զ����Interceptering filter
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
