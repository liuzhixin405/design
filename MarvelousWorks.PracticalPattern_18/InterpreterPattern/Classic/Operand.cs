using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.InterpreterPattern.Classic
{
    /// <summary>
    /// 表示所有操作数
    /// </summary>
    public class Operand : IExpression
    {
        int num;
        public Operand(int num) { this.num = num; }
        /// <summary>
        /// 根据操作符执行计算
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
