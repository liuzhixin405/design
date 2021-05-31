using System;
namespace MarvellousWorks.PracticalPattern.SingletonPattern.Generic
{
    /// <summary>
    /// ����һ���Ƿ��͵ĳ������
    /// ��������Լ���ϣ�ֻ�� T : class, new()����Զ���Լ�������Ͻ���
    /// </summary>
    public interface ISingleton{}   

    public abstract class SingletonBase<T> : ISingleton
        where T : ISingleton, new()
    {
        protected static T instance = new T();
        public static T Instance { get { return instance; } }
    }
}
