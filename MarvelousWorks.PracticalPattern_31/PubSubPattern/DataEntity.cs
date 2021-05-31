using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.PubSubPattern
{
    /// <summary>
    /// 便于按照Key从持久层检索对象的抽象
    /// </summary>
    public interface IObjectWithKey
    {
        string Key { get;}
    }

    /// <summary>
    /// 预定发布内容对象
    /// <remarks>
    /// 其内容可以是各种通用的数据类型，例如：
    /// <list type="bullet">
    ///     <item>string</item>
    ///     <item>DataSet</item>
    ///     <item>Stream</item>
    ///     <item>XmlDocument</item>
    /// </list>
    /// 这里为了简化，采用了string
    /// </remarks>
    /// </summary>
    public class Article : IObjectWithKey
    {
        private string category;
        public string Category
        {
            get { return category; }
            set { category = value; }
        }

        private string content;
        public string Content 
        {
            get{return content;}
            set{content = value;}
        }

        public Article(string category, string content)
        {
            this.category = category;
            this.content = content;
        }

        #region IObjectWithKey Members
        public virtual string Key
        {
            get { return category; }
        }
        #endregion
    }


    /// <summary>
    /// Publishder 抛出的预定事件
    /// </summary>
    public class Event : IObjectWithKey
    {
        public string id = Guid.NewGuid().ToString();
        public string ID
        {
            get { return id; }
        }

        private Article article;
        public Article Article
        {
            get { return article; }
        }

        public Event(Article article)
        {
            this.article = article;
        }

        #region IObjectWithKey Members
        public virtual string Key
        {
            get { return ID; }
        }
        #endregion
    }


    /// <summary>
    /// 订阅情况
    /// </summary>
    public class ArticleSubscription : IObjectWithKey
    {
        private Article article;
        public Article Article
        {
            get { return article; }
        }

        private ISubscriber subscriber;
        public ISubscriber Subscriber
        {
            get { return subscriber; }
        }

        public ArticleSubscription(Article article, ISubscriber subscriber)
        {
            this.article = article;
            this.subscriber = subscriber;
        }

        #region IObjectWithKey Members
        public virtual string Key
        {
            get 
            {
                return ((IObjectWithKey)article).Key + 
                    subscriber.GetHashCode().ToString(); 
            }
        }
        #endregion
    }

    /// <summary>
    /// 通知
    /// <remarks>
    /// 由于通知是事件发生后，根据预定条件筛选出来的内容，
    /// 这里为了简化示例，采用直接继承的方式
    /// </remarks>
    /// </summary>
    public class Notification : IObjectWithKey
    {
        private Event e;
        public Event Event
        {
            get { return e; }
        }

        private ISubscriber subscriber;
        public ISubscriber Subscriber
        {
            get { return subscriber; }
        }
    
        public Notification(Event e, ISubscriber subscriber)
        {
            this.e = e;
            this.subscriber = subscriber;
        }

        #region IObjectWithKey Members
        public string Key
        {
            get { return e.ID + subscriber.GetHashCode().ToString(); }
        }
        #endregion
    }
}
