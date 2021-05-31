using System;
using System.Web;
using MarvellousWorks.PracticalPattern.Common;
namespace MarvellousWorks.PracticalPattern.SingletonPattern.Combined
{
    public class Singleton
    {
        private const string Key = "marvellousWorks.practical.singleton";
        private Singleton() { }     // �����չ���

        [ThreadStatic]
        private static Singleton instance;

        public static Singleton Instance
        {
            get
            {
                // ͨ��֮ǰ׼����GenericContext�зǹٷ��ķ���
                // �жϵ�ǰִ��ģʽ��Web Form���Ƿ�Web Form
                // ������û����.NET��CF��MF����֤��
                if (GenericContext.CheckWhetherIsWeb())     // Web Form
                {
                    // ����HttpContext��Lazyʵ��������
                    Singleton instance =
                        (Singleton)HttpContext.Current.Items[Key];
                    if (instance == null)
                    {
                        instance = new Singleton();
                        HttpContext.Current.Items[Key] = instance;
                    }
                    return instance;
                }
                else  // ��Web Form��ʽ
                {
                    if (instance == null)
                        instance = new Singleton();
                    return instance;
                }
            }
        }
    }
}