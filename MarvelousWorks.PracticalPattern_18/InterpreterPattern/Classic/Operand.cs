using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.InterpreterPattern.Classic
{
    /// <summary>
    /// ��ʾ���в�����
    /// </summary>
    public class Operand : IExpression
    {
        int num;
        public Operand(int num) { this.num = num; }
        /// <summary>
        /// ���ݲ�����ִ�м���
        /// </summary>
        /// <param name="c"></param>
        public virtual void Evaluate(Context c)
        {
            switch (c.Operator)
            {
                case '\0': c.Value = num; break;
                case '+': c.Value += num; break;
                case '-': c.Value -= num; break;
            }
        }
    }
}
