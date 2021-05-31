using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.InterpreterPattern.Classic
{
    /// <summary>
    /// ��ʾ���в�����
    /// </summary>
    public class Operator : IExpression
    {
        private char op;
        public Operator(char op) { this.op = op; }
        public virtual void Evaluate(Context context) { context.Operator = op; }
    }
}
