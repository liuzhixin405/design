using System;
namespace MarvellousWorks.PracticalPattern.BuilderPattern.Generics
{
    /// <summary>
    /// �������о���"type"���Ե�������Ϣ����������һ������Ԫ��Ҳ���������ýڣ�
    /// ��Builder����ʵ��������ӿڵ����ö�����д�����Ϊֻ������������������
    /// �Ĳ�Ʒ������Ϣ��
    /// </summary>
    public interface IConfigurationSource
    {
        Type Type { get; set;}
    }
}
