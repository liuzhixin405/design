using System;
using System.Configuration;
namespace MarvellousWorks.PracticalPattern.SingletonPattern.Parameterized
{
public class Singleton
{
    /// <summary>
    /// ���������캯��
    /// </summary>
    /// <param name="message"></param>
    private string message;
    private Singleton(string message) { this.message = message; }
    public string Message { get { return this.message; } }

    /// <summary>
    /// ͨ����������ʵ�ֵĲ�����Singletonʵ������
    /// </summary>
    private static Singleton instance;
    public static Singleton Instance
    {
        get
        {
            if (instance == null)
                lock(typeof(Singleton))
                    if (instance == null)
                    {
                        /// ��ȡ���ò�����ʵ����
                        string key = "parameterizedSingletonMessage";
                        string message = ConfigurationManager.AppSettings[key];
                        instance = new Singleton(message);
                    }
            return instance;
        }
    }
}
}

                            //if ((DateTime.Now.DayOfWeek == DayOfWeek.Sunday) ||
                            //    (DateTime.Now.DayOfWeek == DayOfWeek.Saturday))
                            //    instance = new Singleton("weekend");
                            //else
                            //    instance = new Singleton("work day");