using System;
using System.Web;
using MarvellousWorks.PracticalPattern.Common;
namespace MarvellousWorks.PracticalPattern.SingletonPattern.Combined
{
    public class Singleton
    {
        private const string Key = "marvellousWorks.practical.singleton";
        private Singleton() { }     // 对外封闭构造

        [ThreadStatic]
        private static Singleton instance;

        public static Singleton Instance
        {
            get
            {
                // 通过之前准备的GenericContext中非官方的方法
                // 判断当前执行模式是Web Form还是非Web Form
                // 本方法没有在.NET的CF和MF上验证过
                if (GenericContext.CheckWhetherIsWeb())     // Web Form
                {
                    // 基于HttpContext的Lazy实例化过程
                    Singleton instance =
                        (Singleton)HttpContext.Current.Items[Key];
                    if (instance == null)
                    {
                        instance = new Singleton();
                        HttpContext.Current.Items[Key] = instance;
                    }
                    return instance;
                }
                else  // 非Web Form方式
                {
                    if (instance == null)
                        instance = new Singleton();
                    return instance;
                }
            }
        }
    }
}