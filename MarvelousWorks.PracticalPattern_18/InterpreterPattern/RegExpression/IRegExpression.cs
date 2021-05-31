using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace MarvellousWorks.PracticalPattern.InterpreterPattern.RegExpression
{
    /// <summary>
    /// ����������ʽ��ʽ��ʾ�ĳ���ӿ�
    /// </summary>
    public interface IRegExpression : IExpression
    {
        /// <summary>
        /// �Ƿ�ƥ��
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        bool IsMatch(string content);
    }

    /// <summary>
    /// ����������ʽ��ʽ��ʾ�ĳ������
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
        /// �������ʽ
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
        /// ͨ��Match��ʽ�������ʽ�����Ա����า��
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
        /// ͨ��Replace�����滻���ݣ����Ա����า��
        /// </summary>
        /// <param name="context"></param>
        protected virtual void EvaluateReplace(Context context)
        {
            context.Content = regex.Replace(context.Content, context.Replacement);
        }
    }
}
