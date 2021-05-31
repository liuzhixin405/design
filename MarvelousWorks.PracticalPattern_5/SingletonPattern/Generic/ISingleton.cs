using System;
namespace MarvellousWorks.PracticalPattern.SingletonPattern.Generic
{
    /// <summary>
    /// 定义一个非泛型的抽象基础
    /// 否则类型约束上，只能 T : class, new()，相对而言约束不够严谨。
    /// </summary>
    public interface ISingleton{}   

    public abstract class SingletonBase<T> : ISingleton
        where T : ISingleton, new()
    {
        protected static T instance = new T();
        public static T Instance { get { return instance; } }
    }
}
