using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.InterpreterPattern.RegExpression
{
    /// <summary>
    /// 电子邮件
    /// </summary>
    public class EmailRegExpression : RegExpressionBase
    {
        public EmailRegExpression()
            : base(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*") { }
    }

    /// <summary>
    /// 汉字
    /// </summary>
    public class ChineseRegExpression : RegExpressionBase
    {
        public ChineseRegExpression()
            :base(@"^[\u4e00-\u9fa5]{0,}$") { }
    }

    /// <summary>
    /// 普通的字符串
    /// </summary>
    public class StringRegExpression : RegExpressionBase
    {
        public StringRegExpression(string expression) : base(expression) { }
    }
}
