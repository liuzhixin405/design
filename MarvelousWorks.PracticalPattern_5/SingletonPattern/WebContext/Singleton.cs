using System;
using System.Collections.Generic;
using System.Web;
namespace MarvellousWorks.PracticalPattern.SingletonPattern.WebContext
{
    public class Singleton
    {
        /// <summary>
        /// 足够复杂的一个key值，用于和HttpContext中的其他内容相区别
        /// </summary>
        private const string Key = "marvellousWorks.practical.singleton";
        private Singleton() { }

        public static Singleton Instance
        {
            get
            {
                // 基于HttpContext的Lazy实例化过程
                Singleton instance = (Singleton)HttpContext.Current.Items[Key];
                if (instance == null)
                {
                    instance = new Singleton();
                    HttpContext.Current.Items[Key] = instance;
                }
                return instance;
            }
        }
    }
}
