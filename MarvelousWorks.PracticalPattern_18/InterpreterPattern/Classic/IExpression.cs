using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.InterpreterPattern.Classic
{
    /// <summary>
    /// ��ʾ���б��ʽ�ĳ���ӿ�
    /// </summary>
    public interface IExpression
    {
        /// <summary>
        /// ��Context���𱣴��м���
        /// </summary>
        /// <param name="context"></param>
        void Evaluate(Context context);
    }
}
