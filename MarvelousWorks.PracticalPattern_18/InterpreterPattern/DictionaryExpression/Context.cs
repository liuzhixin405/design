using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.InterpreterPattern.DictionaryExpression
{
    /// <summary>
    /// �������ֵ���Ϣ��Context����
    /// </summary>
    public class Context
    {
        public object Key;
        public object Value;
        /// <summary>
        /// 'T'(to) ����Value���Key
        /// 'F'(from) ����Key���Value
        /// </summary>
        public char Operator;
    }
}
