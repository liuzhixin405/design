using System;
namespace MarvellousWorks.PracticalPattern.BuilderPattern.Generics
{
    /// <summary>
    /// 由于在这种情况下，Builder需要完成的工作相对比较复杂，不太可能会直接
    /// 暴露出BuildPart()的细节，况且每个BuildPart()过程本身就是通过反射动态
    /// 发起的，因此定义上只有一个BuildUp()方法。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBuilder<T>
        where T : IObjectWithType
    {
        T BuildUp();
    }
}
