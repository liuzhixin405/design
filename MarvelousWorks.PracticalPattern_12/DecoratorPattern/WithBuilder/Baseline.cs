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
    /// ����װ����
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
    ///  ����װ����
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
    /// ����װ����
    /// </summary>
    public class BlockAllDecorator : DecoratorBase
    {
        public BlockAllDecorator(IText target) : base(target) { }
    }

    /// <summary>
    /// ʵ���������
    /// </summary>
    public class TextObject : IText
    {
        public string Content { get { return "hello"; } }
    }
}
