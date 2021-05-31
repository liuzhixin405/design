using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.MediatorPattern.Classic
{
    /// <summary>
    /// 协同对象接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IColleague<T>
    {
        T Data { get; set;}
        IMediator<T> Mediator { get; set;}
    }

    public abstract class ColleagueBase<T> : IColleague<T>
    {
        protected T data;
        protected IMediator<T> mediator;

        public virtual T Data
        {
            get { return data; }
            set { data = value; }
        }

        public virtual IMediator<T> Mediator
        {
            get { return mediator; }
            set { mediator = value; }
        }
    }
}
