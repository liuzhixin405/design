using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.MediatorPattern.Delegating
{
    public class DataEventArgs<T> : EventArgs
    {
        public T Data;
        public DataEventArgs(T data) { this.Data = data; }
    }

    public abstract class ColleagueBase<T> 
    {
        protected T data;
        public virtual T Data
        {
            get { return data; }
            set { data = value; }
        }

        public virtual void OnChanged(object sender, DataEventArgs<T> args)
        {
            Data = args.Data;
        }
    }
}
