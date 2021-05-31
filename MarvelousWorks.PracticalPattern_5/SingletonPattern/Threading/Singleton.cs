using System;
namespace MarvellousWorks.PracticalPattern.SingletonPattern.Threading
{
    public class Singleton
    {
        private Singleton() { }

        [ThreadStatic]  // ˵��ÿ��Instance���ڵ�ǰ�߳��ھ�̬
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
