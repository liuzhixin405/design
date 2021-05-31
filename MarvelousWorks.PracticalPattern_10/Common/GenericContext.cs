using System;
using System.Collections.Generic;
using System.Web;
namespace MarvellousWorks.PracticalPattern.Common
{
    /// <summary>
    /// 通用的自定义上下文对象
    /// </summary>
    public class GenericContext
    {
        /// <summary>
        /// 由于内部操作上，所有的容器类型均为 Dictionary<string, object>
        /// 所以定义一个固定的类型名称。
        /// </summary>
        class NameBasedDictionary : Dictionary<string, object> { }


        /// <summary>
        /// 用于 Windows 应用的线程级上下文成员容器
        /// </summary>
        [ThreadStatic]
        private static NameBasedDictionary threadCache;
        /// <summary>
        /// 标识当前应用是否为 Web 应用
        /// </summary>
        private static readonly bool isWeb = CheckWhetherIsWeb();
        /// <summary>
        /// Web 应用中 Context 保存的键值
        /// </summary>
        private const string ContextKey = "marvellousWorks.context.web";


        /// <summary>
        /// 对于 Web 应用，如果HttpContext对应内容元素没有初始化，则放置一个空容器。
        /// 对于 Windows 应用，由于 threadCache 为 [ThreadStatic]，无需该过程。
        /// </summary>
        public GenericContext()
        {
            if (isWeb && (HttpContext.Current.Items[ContextKey] == null))
                    HttpContext.Current.Items[ContextKey] = new NameBasedDictionary();
        }



        /// <summary>
        /// 根据上下文成员名称，返回对应内容的。
        /// <remarks>
        /// 由于 threadCache 或 HttpContext 中的缓冲对象都会在构造过程中创建
        //  因此，这里没有对 cache == null 的判断。
        /// </remarks>
        /// </summary>
        /// <param name="name">上下文成员键值。</param>
        /// <returns>对应内容</returns>
        public object this[string name]
        {
            get
            {
                if (string.IsNullOrEmpty(name)) return null;
                NameBasedDictionary cache = GetCache();
                if (cache.Count <= 0) return null;
                object result;
                if (cache.TryGetValue(name, out result))
                    return result;
                else
                    return null;
            }
            set
            {
                if (string.IsNullOrEmpty(name)) return;
                NameBasedDictionary cache = GetCache();
                object temp;
                if (cache.TryGetValue(name, out temp))
                    cache[name] = value;
                else
                    cache.Add(name, value);
            }
        }



        /// <summary>
        /// 根据应用类型获取相应上下文缓冲对象。
        /// </summary>
        /// <returns>缓冲对象。</returns>
        private static NameBasedDictionary GetCache()
        {
            NameBasedDictionary cache;
            if (isWeb)
                cache = (NameBasedDictionary)HttpContext.Current.Items[ContextKey];
            else
                cache = threadCache;
            if (cache == null)
                cache = new NameBasedDictionary();
            if (isWeb)
                HttpContext.Current.Items[ContextKey] = cache;
            else
                threadCache = cache;
            return cache;
        }

        /// <summary>
        /// 判断当前应用是否为 Web 应用的 Helper 方法 （非官方方法）
        /// </summary>
        /// <returns></returns>
        public static bool CheckWhetherIsWeb()
        {
            bool result = false;
            AppDomain domain = AppDomain.CurrentDomain;
            try
            {
                if (domain.ShadowCopyFiles)
                    result = (HttpContext.Current.GetType() != null);
            }
            catch (System.Exception){}
            return result;
        }
    }
}
