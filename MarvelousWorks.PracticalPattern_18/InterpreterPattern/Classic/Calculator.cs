using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.InterpreterPattern.Classic
{
    /// <summary>
    /// ������
    /// </summary>
    public class Calculator
    {
        public int Calculate(string expression)
        {
            Context context = new Context();
            IList<IExpression> tree = new List<IExpression>();
            // �ʷ����﷨����
            char[] elements = expression.ToCharArray();
            foreach (char c in elements)
            {
                if ((c == '+') || (c == '-'))
                    tree.Add(new Operator(c));
                else
                    tree.Add(new Operand((int)(c - 48)));
            }
            // ����ִ��ÿ���м����
            foreach (IExpression exp in tree)
                exp.Evaluate(context);
            return context.Value;
        }
    }
}
