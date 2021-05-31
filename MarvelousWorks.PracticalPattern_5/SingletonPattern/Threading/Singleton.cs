using System;
namespace MarvellousWorks.PracticalPattern.SingletonPattern.Threading
{
    public class Singleton
    {
        private Singleton() { }

        [ThreadStatic]  // 说明每个Instance仅在当前线程内静态
        private static Singleton instance;

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                    instance = new Singleton();
                return instance;
            }
        }
    }
}
