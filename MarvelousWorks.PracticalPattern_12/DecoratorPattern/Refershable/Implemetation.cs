using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
namespace MarvellousWorks.PracticalPattern.DecoratorPattern.Refershable
{
    public class BoldState : IState
    {
        public bool IsBold;

        public bool Equals(IState newState)
        {
            if (newState == null) return false;
            return ((BoldState)newState).IsBold == IsBold;
        }
    }

    /// <summary>
    /// 具体装饰类
    /// </summary>
    public class BoldDecorator : DecoratorBase
    {
        public BoldDecorator(IText target) : base(target) { base.state = new BoldState(); }
        public override string Content
        {
            get
            {
                if (((BoldState)State).IsBold)
                    return "<b>" + target.Content + "</b>";
                else
                    return target.Content;
            }
        }
    }

    public class ColorState : IState
    {
        public Color Color = Color.Black;

        public bool Equals(IState newState)
        {
            if (newState == null) return false;
            return (((ColorState)newState).Color == Color);
        }
    }

    /// <summary>
    ///  具体装饰类
    /// </summary>
    public class ColorDecorator : DecoratorBase
    {
        public ColorDecorator(IText target) : base(target) { base.state = new ColorState(); }
        public override string Content
        {
            get
            {
                string colorName = (((ColorState)State).Color).Name;
                return "<" + colorName + ">" + target.Content + "</" + colorName + ">";
            }
        }
    }

    /// <summary>
    /// 实体对象类型
    /// </summary>
    public class TextObject : IText 
    {
        public string Content { get { return "hello"; } }
    }
}
