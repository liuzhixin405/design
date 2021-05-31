namespace MarvellousWorks.PracticalPattern.SingletonPattern.DoubleCheckClassic
{
    public class Singleton
    {
        protected Singleton() { }
        private static volatile Singleton instance = null;

        /// <summary>
        /// Lazy��ʽ����Ψһʵ���Ĺ���
        /// </summary>
        /// <returns></returns>
        public static Singleton Instance()
        {
            if (instance == null)           // ���if
                lock (typeof(Singleton))    // ���߳��й�����Դͬ��
                    if (instance == null)   // �ڲ�if
                        instance = new Singleton();
            return instance;
        }
    }
}

