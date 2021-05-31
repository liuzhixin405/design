namespace MarvellousWorks.PracticalPattern.SingletonPattern.SimplestCounter
{
    public class Counter
    {
        private Counter() { }
        public static readonly Counter Instance = new Counter();

        private int value;
        public int Next { get { return ++value; } }
        public void Reset() { value = 0; }
    }
}
