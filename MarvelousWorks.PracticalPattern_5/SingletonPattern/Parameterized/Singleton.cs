using System;
using System.Configuration;
namespace MarvellousWorks.PracticalPattern.SingletonPattern.Parameterized
{
public class Singleton
{
    /// <summary>
    /// 参数化构造函数
    /// </summary>
    /// <param name="message"></param>
    private string message;
    private Singleton(string message) { this.message = message; }
    public string Message { get { return this.message; } }

    /// <summary>
    /// 通过访问配置实现的参数化Singleton实例构造
    /// </summary>
    private static Singleton instance;
    public static Singleton Instance
    {
        get
        {
            if (instance == null)
                lock(typeof(Singleton))
                    if (instance == null)
                    {
                        /// 读取配置并进行实例化
                        string key = "parameterizedSingletonMessage";
                        string message = ConfigurationManager.AppSettings[key];
                        instance = new Singleton(message);
                    }
            return instance;
        }
    }
}
}

                            //if ((DateTime.Now.DayOfWeek == DayOfWeek.Sunday) ||
                            //    (DateTime.Now.DayOfWeek == DayOfWeek.Saturday))
                            //    instance = new Singleton("weekend");
                            //else
                            //    instance = new Singleton("work day");