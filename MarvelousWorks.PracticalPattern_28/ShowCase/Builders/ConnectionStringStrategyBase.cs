using System;
using System.Configuration;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.ShowCase.Builders
{
    /// <summary>
    /// ���Ӵ����������һ������Ĵ����㷨
    /// </summary>
    public abstract class ConnectionStringStrategyBase
    {
        /// <summary>
        /// ��������ʵ�ֵ��㷨���崦����
        /// </summary>
        /// <returns></returns>
        public abstract void Process(ref ConnectionStringSettings setting);
    }
}
