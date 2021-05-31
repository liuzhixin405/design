using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.PubSubPattern
{
    /// <summary>
    /// ���ڰ���Key�ӳ־ò��������ĳ���
    /// </summary>
    public interface IObjectWithKey
    {
        string Key { get;}
    }

    /// <summary>
    /// Ԥ���������ݶ���
    /// <remarks>
    /// �����ݿ����Ǹ���ͨ�õ��������ͣ����磺
    /// <list type="bullet">
    ///     <item>string</item>
    ///     <item>DataSet</item>
    ///     <item>Stream</item>
    ///     <item>XmlDocument</item>
    /// </list>
    /// ����Ϊ�˼򻯣�������string
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
    /// Publishder �׳���Ԥ���¼�
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
    /// �������
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
    /// ֪ͨ
    /// <remarks>
    /// ����֪ͨ���¼������󣬸���Ԥ������ɸѡ���������ݣ�
    /// ����Ϊ�˼�ʾ��������ֱ�Ӽ̳еķ�ʽ
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
