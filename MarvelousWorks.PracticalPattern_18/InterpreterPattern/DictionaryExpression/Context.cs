using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.InterpreterPattern.DictionaryExpression
{
    /// <summary>
    /// 适用于字典信息的Context对象
    /// </summary>
    public class Context
    {
        public object Key;
        public object Value;
        /// <summary>
        /// 'T'(to) 根据Value获得Key
        /// 'F'(from) 根据Key获得Value
        /// </summary>
        public char Operator;
    }
}
