using System;
namespace MarvellousWorks.PracticalPattern.BuilderPattern.Generics
{
    /// <summary>
    /// ����Ĳ�Ʒ���ͣ�������һ��Type���ԣ�Ŀ����Ϊ����IBuilder���Ը���������Դ������ļ���
    /// �ҵ�������������������û�в��á�IProduct�����ƣ���Ҫ�Ǿ���Enterprise Library�������
    /// ��������ȥ�����С�
    /// </summary>
    public interface IObjectWithType
    {
        Type Type{get; set;}
    }
}
