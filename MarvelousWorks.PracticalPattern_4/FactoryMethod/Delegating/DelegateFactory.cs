using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.FactoryMethod.Delegating
{
    /// <summary>
    /// 委托本质上就是对具体执行方法的抽象，它相当于Product的角色
    /// </summary>
    /// <param name="items"></param>
    /// <returns></returns>
    public delegate int CalculateHandler (params int[] items);

    class Calculator
    {
        /// <summary>
        /// 这个方法相当于Delegate Factory看到的Concrete Product
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public int Add(params int[] items)
        {
            int result = 0;
            foreach (int item in items)
                result += item;
            return result;
        }
    }

    /// <summary>
    /// Concrete Factory
    /// </summary>
    public class CalculateHandlerFactory : IFactory<CalculateHandler>
    {
        public CalculateHandler Create()
        {
            return (new Calculator()).Add;
        }
    }
}
