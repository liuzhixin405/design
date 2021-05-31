using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.StrategyPattern.WithInterpreter
{

    public enum RuleFocus
    {
        Speed,      // ��ע���ٶ�
        Simplicity  // ��ע��ʵ�ּ�
    }

    /// <summary>
    /// ������Զ���
    /// </summary>
    public interface IStrategy
    {
        int[] Sort(int[] data);
    }

    /// <summary>
    /// ����Context����
    /// </summary>
    public interface IContext
    {
        IStrategy Strategy { get; set;}

    }
}
