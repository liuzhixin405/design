using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.InterpreterPattern.Classic
{
    /// <summary>
    /// 用于保存计算过程的中间结果以及当前执行的操作符
    /// </summary>
    public class Context
    {
        public int Value;
        public char Operator;
    }
}
