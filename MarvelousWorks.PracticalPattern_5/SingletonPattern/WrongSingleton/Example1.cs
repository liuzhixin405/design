using System;
using System.Collections.Generic;
using System.Text;

namespace MarvellousWorks.PracticalPattern.SingletonPattern.WrongSingleton
{
    /// �����龰1
public class BaseEntity : System.ICloneable
{
    public object Clone()   // �Ե�ǰʵ�����п�¡
    {
        return this.MemberwiseClone();  // ����������ַ�ʽ��¡
    }
}

public class Singleton : BaseEntity
{
    // ... ...
}
}

    ///// <summary>
    ///// ��Singleton ʵ��ͨ�������ƴ��л�Ϊ�ַ���
    ///// </summary>
    ///// <param name="graph"></param>
    ///// <returns></returns>
    //public static string SerializeToString(Singleton graph)
    //{
    //    MemoryStream memoryStream = new MemoryStream();
    //    formatter.Serialize(memoryStream, graph);

    //    Byte[] arrGraph = memoryStream.ToArray();
    //    return Convert.ToBase64String(arrGraph);
    //}

    ///// <summary>
    ///// ͨ�������Ʒ����л����ַ����ظ���Singleton ʵ��
    ///// </summary>
    ///// <param name="serializedGraph"></param>
    ///// <returns></returns>
    //public static Singleton DeserializeFromString(string serializedGraph)
    //{
    //    Byte[] arrGraph = Convert.FromBase64String(serializedGraph);
    //    MemoryStream memoryStream = new MemoryStream(arrGraph);

    //    return (Singleton)formatter.Deserialize(memoryStream);
    //}
