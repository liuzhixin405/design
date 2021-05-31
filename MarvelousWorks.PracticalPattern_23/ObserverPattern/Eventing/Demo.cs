using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.ObserverPattern.Eventing
{
    /// <summary>
    /// ¾ßÌåµÄSubject
    /// </summary>
    public class UserEventArgs : EventArgs
    {
        private string name;
        public UserEventArgs(string name) { this.name = name; }
        public string Name { get { return this.name; } }
    }

    public class User
    {
        public event EventHandler<UserEventArgs> NameChanged;

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                // notify
                NameChanged(this, new UserEventArgs(value));
            }
        }
    }
}
