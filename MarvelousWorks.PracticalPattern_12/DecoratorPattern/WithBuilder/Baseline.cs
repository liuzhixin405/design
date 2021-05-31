using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.DecoratorPattern.WithBuilder
{
    public interface IText
    {
        string Content { get;}
    }

    public interface IDecorator : IText { }
    public abstract class DecoratorBase : IDecorator    // is a
    {
        protected IText target;
        public DecoratorBase(IText target) { this.target = target; }
        public virtual string Content { get { return target.Content; } }
    }

    /// <summary>
    /// 具体装饰类
    /// </summary>
    public class BoldDecorator : DecoratorBase
    {
        public BoldDecorator(IText target) : base(target) { }
        public override string Content
        {
            get { return ChangeToBoldFont(target.Content); }
        }

        public string ChangeToBoldFont(string content)
        {
            return "<b>" + content + "</b>";
        }
    }

    /// <summary>
    ///  具体装饰类
    /// </summary>
    public class ColorDecorator : DecoratorBase
    {
        public ColorDecorator(IText target) : base(target) { }
        public override string Content
        {
            get { return AddColorTag(target.Content); }
        }

        public string AddColorTag(string content)
        {
            return "<color>" + target.Content + "</color>";
        }
    }

    /// <summary>
    /// 具体装饰类
    /// </summary>
    public class BlockAllDecorator : DecoratorBase
    {
        public BlockAllDecorator(IText target) : base(target) { }
    }

    /// <summary>
    /// 实体对象类型
    /// </summary>
    public class TextObject : IText
    {
        public string Content { get { return "hello"; } }
    }
}
