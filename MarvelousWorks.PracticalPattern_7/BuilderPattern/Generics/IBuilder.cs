using System;
namespace MarvellousWorks.PracticalPattern.BuilderPattern.Generics
{
    /// <summary>
    /// ��������������£�Builder��Ҫ��ɵĹ�����ԱȽϸ��ӣ���̫���ܻ�ֱ��
    /// ��¶��BuildPart()��ϸ�ڣ�����ÿ��BuildPart()���̱������ͨ�����䶯̬
    /// ����ģ���˶�����ֻ��һ��BuildUp()������
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBuilder<T>
        where T : IObjectWithType
    {
        T BuildUp();
    }
}
