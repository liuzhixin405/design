using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.CommandPattern.Classic
{
    /// <summary>
    /// 实际动作的执行者
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
