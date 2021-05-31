using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.InterpreterPattern.RegExpression
{
    /// <summary>
    /// 用于保存计算过程的中间结果以及当前执行的操作符
    /// 根据Regex的功能操作符包括：Matches(M)、Replace(R)
    /// </summary>
    public class Context
    {
        /// <summary>
        /// 文本内容
        /// </summary>
        public string Content; 
        /// <summary>
        /// 'M' Matches /'R' Replace
        /// </summary>
        public char Operator;  
        /// <summary>
        /// 匹配字符串集合
        /// </summary>
        public IList<string> Matches = new List<string>();
        /// <summary>
        /// 用于替换的文本内容
        /// </summary>
        public string Replacement;
    }
}
