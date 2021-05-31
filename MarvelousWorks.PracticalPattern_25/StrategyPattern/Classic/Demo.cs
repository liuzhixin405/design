using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.StrategyPattern.Classic
{
    /// <summary>
    /// ������Զ���
    /// </summary>
    public interface IStrategy
    {
        /// <summary>
        /// �㷨��Ҫ��ɵĹ���
        /// �����ǰ��վ�����Ե�Ҫ����ȡ��ĳһ�����ݼ���
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int PickUp(int[] data);
    }

    /// <summary>
    /// ����Context����
    /// </summary>
    public interface IContext
    {
        IStrategy Strategy { get; set;}
        int GetData(int[] data);
    }
}
