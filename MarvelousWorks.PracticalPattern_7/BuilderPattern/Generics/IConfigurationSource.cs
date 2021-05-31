using System;
namespace MarvellousWorks.PracticalPattern.BuilderPattern.Generics
{
    /// <summary>
    /// 定义所有具有"type"属性的配置信息，它可能是一个配置元素也可能是配置节，
    /// 但Builder仅对实现了这个接口的配置对象进行处理，因为只有他标明了他所服务
    /// 的产品类型信息。
    /// </summary>
    public interface IConfigurationSource
    {
        Type Type { get; set;}
    }
}
