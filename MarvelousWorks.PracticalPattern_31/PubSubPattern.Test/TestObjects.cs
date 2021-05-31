using System;
using System.Collections;
using System.Collections.Generic;
using MarvellousWorks.PracticalPattern.PubSubPattern;
namespace MarvellousWorks.PracticalPattern.PubSubPattern.Test
{
    /// <summary>
    /// 示例用的测试用内存持久化机制
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class KeyedObjectStore<T> : IKeyedObjectStore<T>
        where T : class, IObjectWithKey
    {
        protected IDictionary<string, T> data = new Dictionary<string, T>();

        public virtual void Save(T target)
        {
            if (target == null) throw new ArgumentNullException("target");
            data.Add(target.Key, target);
        }

        public virtual T Select(string key)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException("key");
            T result;
            if (data.TryGetValue(key, out result))
                return result;
            else
                return null;
        }

        public virtual void Remove(string key)
        {
            data.Remove(key);
        }

        public IEnumerator GetEnumerator() 
        {
            foreach (T value in data.Values)
                yield return value;
        }
    }

    /// <summary>
    /// 示例用的预定事件持久化
    /// </summary>
    public class ExtEventArgs : EventArgs
    {
        private Event e;
        public Event Event
        {
            get { return e; }
        }

        public ExtEventArgs(Event e)
        {
            this.e = e;
        }
    }

    public class EventStore : KeyedObjectStore<Event>
    {
        public EventHandler<ExtEventArgs> NewEventOccured;

        public override void Save(Event target)
        {
            base.Save(target);
            if (NewEventOccured != null)
                NewEventOccured(this, new ExtEventArgs(target));
        }
    }

    /// <summary>
    /// 示例用的通知事件持久化
    /// </summary>
    public class NotificationEventArgs : EventArgs
    {
        private Notification notification;
        public Notification Notification
        {
            get { return notification; }
        }

        public NotificationEventArgs(Notification notification)
        {
            this.notification = notification;
        }
    }
    public class NotificationStore : KeyedObjectStore<Notification>
    {
        public event EventHandler<NotificationEventArgs> NewNotificationOccured;

        public override void Save(Notification target)
        {
            base.Save(target);
            if (NewNotificationOccured != null)
                NewNotificationOccured(this, new NotificationEventArgs(target));
        }
    }

    /// <summary>
    /// 示例用的发布信息持久化
    /// </summary>
    public class ArticleStore : KeyedObjectStore<Article>
    {
    }

    /// <summary>
    /// 示例用的预定情况持久化
    /// </summary>
    public class ArticleSubscriptionStore : KeyedObjectStore<ArticleSubscription>
    {
    }

    /// <summary>
    /// 示例用的发布者
    /// </summary>
    public class Publisher : PublisherBase
    {
        public ArticleStore ArticleStore
        {
            set { articleStore = value; }
        }

        public ArticleSubscriptionStore ArticleSubscriptionStore
        {
            set { subscriptionStore = value; }
        }

        public EventStore EventStore
        {
            set { eventStore = value; }
        }
    }

    /// <summary>
    /// 示例用的预定者
    /// </summary>
    public class Subscriber : SubscriberBase
    {
        public IDictionary<string, Queue<string>> Queue
        {
            get { return queue; }
        }
    }

    /// <summary>
    /// 示例用的通知生成器
    /// </summary>
    public class NotificationGenerator
    {
        private EventStore eventStore;
        private NotificationStore notificationStore;
        private ArticleSubscriptionStore articleSubscriptionStore;

        public NotificationGenerator(
            EventStore eventStore,
            NotificationStore notificationStore,
            ArticleSubscriptionStore articleSubscriptionStore)
        {
            this.eventStore = eventStore;
            this.notificationStore = notificationStore;
            this.articleSubscriptionStore = articleSubscriptionStore;

            // 接收新的预定事件
            eventStore.NewEventOccured += OnNewEventOccured;
        }

        /// <summary>
        /// 筛选并生成通知
        /// </summary>
        /// <param name="send"></param>
        /// <param name="args"></param>
        public void OnNewEventOccured(object send, ExtEventArgs args)
        {
            Event e = args.Event;
            string articleKey = e.Article.Key;
            foreach (ArticleSubscription articleSubscription in articleSubscriptionStore)
            {
                string subscriptionArticleKey = ((IObjectWithKey)(articleSubscription.Article)).Key;
                if(string.Equals(articleKey, subscriptionArticleKey))
                {
                    Notification notification =
                        new Notification(e, articleSubscription.Subscriber);
                    notificationStore.Save(notification);
                }
            }
        }
    }

    /// <summary>
    /// 示例用的通知发送对象
    /// </summary>
    public class Distributor
    {
        private NotificationStore notificationStore;
        public Distributor(NotificationStore notificationStore)
        {
            this.notificationStore = notificationStore;

            // 发送新的通知情况
            notificationStore.NewNotificationOccured +=
                OnNewNotificationOccured;
        }

        /// <summary>
        /// 发送新的通知
        /// </summary>
        /// <param name="send"></param>
        /// <param name="args"></param>
        public void OnNewNotificationOccured(object send, NotificationEventArgs args)
        {
            Article article = args.Notification.Event.Article;
            ISubscriber subscriber = args.Notification.Subscriber;
            subscriber.Enqueue(article);
        }
    }
}
