using System;
namespace MarvellousWorks.PracticalPattern.BuilderPattern.Generics
{
    /// <summary>
    /// 抽象的产品类型，他仅有一个Type属性，目的是为了让IBuilder可以根据这个属性从配置文件中
    /// 找到它，并构造它。这里没有采用“IProduct”名称，主要是觉得Enterprise Library启的这个
    /// 名字听上去更贴切。
    /// </summary>
    public interface IObjectWithType
    {
        Type Type{get; set;}
    }
}
