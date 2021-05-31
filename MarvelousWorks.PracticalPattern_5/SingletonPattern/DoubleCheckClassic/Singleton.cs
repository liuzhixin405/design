namespace MarvellousWorks.PracticalPattern.SingletonPattern.DoubleCheckClassic
{
    public class Singleton
    {
        protected Singleton() { }
        private static volatile Singleton instance = null;

        /// <summary>
        /// Lazy方式创建唯一实例的过程
        /// </summary>
        /// <returns></returns>
        public static Singleton Instance()
        {
            if (instance == null)           // 外层if
                lock (typeof(Singleton))    // 多线程中共享资源同步
                    if (instance == null)   // 内层if
                        instance = new Singleton();
            return instance;
        }
    }
}

