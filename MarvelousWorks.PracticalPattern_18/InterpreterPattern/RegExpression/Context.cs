using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.InterpreterPattern.RegExpression
{
    /// <summary>
    /// ���ڱ��������̵��м����Լ���ǰִ�еĲ�����
    /// ����Regex�Ĺ��ܲ�����������Matches(M)��Replace(R)
    /// </summary>
    public class Context
    {
        /// <summary>
        /// �ı�����
        /// </summary>
        public string Content; 
        /// <summary>
        /// 'M' Matches /'R' Replace
        /// </summary>
        public char Operator;  
        /// <summary>
        /// ƥ���ַ�������
        /// </summary>
        public IList<string> Matches = new List<string>();
        /// <summary>
        /// �����滻���ı�����
        /// </summary>
        public string Replacement;
    }
}
