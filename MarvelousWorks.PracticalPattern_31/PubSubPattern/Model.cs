using System;
using System.Collections;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.PubSubPattern
{
    /// <summary>
    /// ����Subscriber�ӿ�
    /// </summary>
    public interface ISubscriber
    {
        /// <summary>
        /// ����Ԥ��
        /// </summary>
        /// <param name="article"></param>
        void Enqueue(Article article);

        /// <summary>
        /// ����Ƿ���ĳ���������Ԥ�����
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        string Peek(string category);

        /// <summary>
        /// ��ȡĳ�������µ�Ԥ�����
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        string Dequeue(string category);
    }

    /// <summary>
    /// ����Subscriber����
    /// </summary>
    public abstract class SubscriberBase : ISubscriber
    {
        /// <summary>
        /// ����������Ľ��ն���
        /// <remarks>
        /// ʵ����Ŀ��������п��ܾ��Ǹ��ڴ滺�壬Ҳ�����Ǿ���ĳ־û�����
        /// </remarks>
        /// </summary>
        protected IDictionary<string, Queue<string>> queue
            = new Dictionary<string, Queue<string>>();

        public virtual void Enqueue(Article article)
        {
            if (article == null) throw new ArgumentNullException("article");
            string category = article.Category;
            if (!queue.ContainsKey(category))
                queue.Add(category, new Queue<string>());
            queue[category].Enqueue(article.Content);
        }

        public virtual string Peek(string category)
        {
            if (!queue.ContainsKey(category))
                return null;
            if (queue[category].Count == 0)
                return null;
            return queue[category].Peek();
        }

        public virtual string Dequeue(string category)
        {
            if (!queue.ContainsKey(category))
                return null;
            if (queue[category].Count == 0)
                return null;
            return queue[category].Dequeue();
        }
    }

    /// <summary>
    /// ����Publisher�ӿ�
    /// </summary>
    public interface IPublisher
    {
        /// <summary>
        /// ����Ԥ����
        /// </summary>
        /// <param name="article"></param>
        /// <param name="subscriber"></param>
        void Subscribe(Article article, ISubscriber subscriber);

        /// <summary>
        /// ����Ԥ����
        /// </summary>
        /// <param name="article"></param>
        /// <param name="subscriber"></param>
        void Unsubscribe(Article article, ISubscriber subscriber);

        /// <summary>
        /// ��ȡ���пɷ����������б�
        /// </summary>
        IEnumerator<Article> Articles { get;}

        /// <summary>
        /// ����Ԥ���¼�
        /// </summary>
        /// <param name="article"></param>
        void Publish(Article article);
    }

    public abstract class PublisherBase : IPublisher
    {
        protected IKeyedObjectStore<Article> articleStore;
        protected IKeyedObjectStore<ArticleSubscription> subscriptionStore;
        protected IKeyedObjectStore<Event> eventStore;

        public virtual void Subscribe(Article article, ISubscriber subscriber)
        {
            if (article == null) throw new ArgumentNullException("article");
            if (subscriber == null) throw new ArgumentNullException("subscriber");
            ArticleSubscription subscription = new ArticleSubscription(article, subscriber);
            string key = ((IObjectWithKey)subscription).Key;
            if (subscriptionStore.Select(key) == null)
                subscriptionStore.Save(subscription);
        }

        public virtual void Unsubscribe(Article article, ISubscriber subscriber)
        {
            if (article == null) throw new ArgumentNullException("article");
            if (subscriber == null) throw new ArgumentNullException("subscriber");
            ArticleSubscription subscription = new ArticleSubscription(article, subscriber);
            subscriptionStore.Remove(((IObjectWithKey)subscription).Key);
        }

        public virtual IEnumerator<Article> Articles
        {
            get
            {
                foreach (Article article in articleStore)
                    yield return article;
            }
        }

        public virtual void Publish(Article article)
        {
            if (article == null) throw new ArgumentNullException("article");
            Event e = new Event(article);
            eventStore.Save(e);
        }
    }

    /// <summary>
    /// ����ĳ־ò����
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IKeyedObjectStore<T> 
        where T : class, IObjectWithKey
    {
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="target"></param>
        void Save(T target);

        /// <summary>
        /// ����Key��ȡ
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        T Select(string key);

        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="key"></param>
        void Remove(string key);

        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        IEnumerator GetEnumerator();
    }
}
