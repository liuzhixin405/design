using System;
using System.Data.Common;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.ShowCase.DataIndependent.OO
{
    /// <summary>
    /// ���ݷ��ʹ��̵��¼�����
    /// </summary>
    public class DbEventArgs : EventArgs
    {
        private DbCommand command;

        /// <summary>
        /// ��Ҫ�׳��������ʻ�������������
        /// </summary>
        public virtual DbCommand Command
        {
            get { return command; }
            set { command = value; }
        }
    }
}
