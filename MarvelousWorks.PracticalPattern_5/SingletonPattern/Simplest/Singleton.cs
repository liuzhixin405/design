using System;
namespace MarvellousWorks.PracticalPattern.SingletonPattern.Simplest
{
    class Singleton
    {
        private Singleton() { }
        [ThreadStatic]
        public static readonly Singleton Instance = new Singleton();
    }

}
