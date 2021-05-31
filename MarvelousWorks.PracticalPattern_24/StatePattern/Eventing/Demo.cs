using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.StatePattern.Eventing
{
    public class GenericEventArgs : EventArgs
    {
        private string value;
        public GenericEventArgs(string value) { this.value = value; }
        public string Value 
        {
            get { return this.value; }
            set { this.value = value; }
        }
    }

    /// <summary>
    /// 某一类 IContext
    /// </summary>
    public class ObjectWithName
    {
        private string name;
        public virtual string Name
        {
            get { return name; }
            set 
            {
                GenericEventArgs eventArgs = new GenericEventArgs(value);
                if(BeforeModifyName !=  null)
                    BeforeModifyName(this, eventArgs);
                name = eventArgs.Value;
            }
        }

        /// <summary>
        /// state.Handle()
        /// </summary>
        public event EventHandler<GenericEventArgs> BeforeModifyName;
    }

    /// <summary>
    /// 外置的 IState Provider 的抽象接口
    /// </summary>
    public interface IStateProvider
    {
        void Handle(object sender, GenericEventArgs eventArgs);
    }


    /// <summary>
    /// 负责将 IContext 与 IState 以更松散的事件方式进行组装的对象
    /// </summary>
    public static class ObjectWithNameAssembler
    {
        public static void Assembly(ObjectWithName target, IStateProvider provider)
        {
            if (target == null) throw new ArgumentNullException("target");
            if (provider == null) throw new ArgumentNullException("provider");
            target.BeforeModifyName += provider.Handle;
        }
    }

    /// <summary>
    /// 宽松限制的外置 IState Provider
    /// </summary>
    public class UnlimitedStateProvider : IStateProvider 
    {
        public void Handle(object sender, GenericEventArgs eventArgs) { }
    }

    /// <summary>
    /// 严格限制的外置 IState Provider
    /// </summary>
    public class RestrictedStateProvider : IStateProvider
    {
        public void Handle(object sender, GenericEventArgs eventArgs)
        {
            if (sender == null) throw new ArgumentNullException("sender");
            if (eventArgs.Value.Length > 10)
                eventArgs.Value = eventArgs.Value.Substring(0, 10);
            if (eventArgs.Value.IndexOf("X") >= 0)
                eventArgs.Value = eventArgs.Value.Replace("X", "Y");
        }
    }
}
