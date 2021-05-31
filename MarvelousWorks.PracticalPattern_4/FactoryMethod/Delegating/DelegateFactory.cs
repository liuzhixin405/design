using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.FactoryMethod.Delegating
{
    /// <summary>
    /// ί�б����Ͼ��ǶԾ���ִ�з����ĳ������൱��Product�Ľ�ɫ
    /// </summary>
    /// <param name="items"></param>
    /// <returns></returns>
    public delegate int CalculateHandler (params int[] items);

    class Calculator
    {
        /// <summary>
        /// ��������൱��Delegate Factory������Concrete Product
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
