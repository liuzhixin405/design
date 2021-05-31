using System;
using System.Collections.Generic;
using System.Text;

namespace MarvellousWorks.PracticalPattern.SingletonPattern.WrongSingleton
{
    /// 错误情景1
public class BaseEntity : System.ICloneable
{
    public object Clone()   // 对当前实例进行克隆
    {
        return this.MemberwiseClone();  // 例如采用这种方式克隆
    }
}

public class Singleton : BaseEntity
{
    // ... ...
}
}

    ///// <summary>
    ///// 把Singleton 实例通过二进制串行化为字符串
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
    ///// 通过二进制反串行化从字符串回复出Singleton 实例
    ///// </summary>
    ///// <param name="serializedGraph"></param>
    ///// <returns></returns>
    //public static Singleton DeserializeFromString(string serializedGraph)
    //{
    //    Byte[] arrGraph = Convert.FromBase64String(serializedGraph);
    //    MemoryStream memoryStream = new MemoryStream(arrGraph);

    //    return (Singleton)formatter.Deserialize(memoryStream);
    //}
