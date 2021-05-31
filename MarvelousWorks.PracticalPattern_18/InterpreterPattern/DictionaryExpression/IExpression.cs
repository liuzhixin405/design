using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.InterpreterPattern.DictionaryExpression
{
    /// <summary>
    /// 表示所有表达式的抽象接口
    /// </summary>
    public interface IExpression
    {
        /// <summary>
        /// 用Context负责保存中间结果
        /// </summary>
        /// <param name="context"></param>
        void Evaluate(Context context);
    }
}
