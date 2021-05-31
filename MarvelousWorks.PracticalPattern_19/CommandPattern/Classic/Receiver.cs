using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.CommandPattern.Classic
{
    /// <summary>
    /// ʵ�ʶ�����ִ����
    /// </summary>
    public class Receiver
    {
        private string name = string.Empty;
        public string Name { get { return name; } }
        private string address = string.Empty;
        public string Address { get { return address; } }

        /// <summary>
        /// Action
        /// </summary>
        public void SetName() { name = "name"; }
        /// <summary>
        /// Action
        /// </summary>
        public void SetAddress() { address = "address"; }
    }
}
