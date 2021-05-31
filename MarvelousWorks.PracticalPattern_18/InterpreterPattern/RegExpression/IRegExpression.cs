using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace MarvellousWorks.PracticalPattern.InterpreterPattern.RegExpression
{
    /// <summary>
    /// 采用正则表达式方式表示的抽象接口
    /// </summary>
    public interface IRegExpression : IExpression
    {
        /// <summary>
        /// 是否匹配
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        bool IsMatch(string content);
    }

    /// <summary>
    /// 采用正则表达式方式表示的抽象基类
    /// </summary>
    public abstract class RegExpressionBase : IRegExpression
    {
        protected Regex regex;
        public RegExpressionBase(string expression)
        {
            regex = new Regex(expression, RegexOptions.Compiled | RegexOptions.IgnoreCase); 
        }
        public virtual bool IsMatch(string content) { return regex.IsMatch(content); }

        /// <summary>
        /// 解析表达式
        /// </summary>
        /// <param name="context"></param>
        public virtual void Evaluate(Context context)
        {
            if (context == null) throw new ArgumentNullException("context");
            switch (context.Operator)
            {
                case 'M':
                    EvaluateMatch(context);
                    break;
                case 'R':
                    EvaluateReplace(context);
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        /// <summary>
        /// 通过Match方式解析表达式，可以被子类覆盖
        /// </summary>
        /// <param name="context"></param>
        protected virtual void EvaluateMatch(Context context)
        {
            context.Matches.Clear();
            MatchCollection coll = regex.Matches(context.Content);
            if (coll.Count == 0) return;
            foreach (Match match in coll)
                context.Matches.Add(match.Value);
        }

        /// <summary>
        /// 通过Replace方法替换内容，可以被子类覆盖
        /// </summary>
        /// <param name="context"></param>
        protected virtual void EvaluateReplace(Context context)
        {
            context.Content = regex.Replace(context.Content, context.Replacement);
        }
    }
}
