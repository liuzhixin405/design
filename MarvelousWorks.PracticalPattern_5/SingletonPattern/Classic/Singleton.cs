namespace MarvellousWorks.PracticalPattern.SingletonPattern.Classic
{
    /// <summary>
    /// 最初经典设计模式中提出的实现方式
    /// </summary>
    public class Singleton
    {
        private static Singleton instance;   // 唯一实例
        protected Singleton() { }   // 封闭客户程序的直接实例化

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
