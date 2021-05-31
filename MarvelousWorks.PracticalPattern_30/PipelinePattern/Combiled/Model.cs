using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.PipelinePattern.Combiled
{
    /// <summary>
    /// ������Pipeline�д��ݴ���Ķ���
    /// </summary>
    public interface IMessage
    {
    }

    /// <summary>
    /// �����Filter����ӿ�
    /// </summary>
    public interface IFilter<T>
        where T : IMessage
    {
        /// <summary>
        /// ÿ��Filter��Ҫִ�еĻ�������
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        T Handle(T message);

        /// <summary>
        /// ��ǰFilterʵ�����ڵ�Pipeline
        /// ��Ҫ��Ϊ���������Filterʱ������ͨ����˷Pipeline
        /// �ҵ�Data  Source��Data Sink
        /// </summary>
        PipelineBase<T> Pipeline { get; set;}
    }

    /// <summary>
    /// ����Filter����
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class FilterBase<T> : IFilter<T>
        where T : IMessage
    {
        public abstract T Handle(T message);

        protected PipelineBase<T> pipeline;
        public virtual PipelineBase<T> Pipeline
        {
            get { return pipeline; }
            set { pipeline = value; }
        }
    }

    /// <summary>
    /// ����Data Source�ӿ�
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDataSource<T>
        where T : IMessage
    {
        T Read();
    }

    /// <summary>
    /// ����Data Sink�ӿ�
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDataSink<T>
        where T : IMessage
    {
        void Write(T message);
    }

    /// <summary>
    /// �����Pipeline����
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class PipelineBase<T>
        where T : IMessage
    {
        protected IList<IFilter<T>> filters = new List<IFilter<T>>();
        protected T message;
        protected IDataSource<T> dataSource;
        protected IDataSink<T> dataSink;

        /// <summary>
        /// ���ε���ÿ��Filter�����Ϣ�Ĵ���
        /// </summary>
        public virtual void Process()
        {
            if (dataSource == null) throw new ArgumentNullException("data source");
            if (dataSink == null) throw new ArgumentNullException("data sink");
            if (message == null) throw new ArgumentNullException("message");
            foreach (IFilter<T> filter in filters)
                message = filter.Handle(message);
        }

        /// <summary>
        /// �����µ�Filter
        /// </summary>
        /// <param name="filter"></param>
        public virtual void Add(IFilter<T> filter)
        {
            if (filter == null) throw new ArgumentNullException("filter");
            filter.Pipeline = this;
            filters.Add(filter);
        }

        /// <summary>
        /// �޳����е�Filter
        /// </summary>
        /// <param name="filter"></param>
        public virtual void Remove(IFilter<T> filter)
        {
            if (filter == null) throw new ArgumentNullException("filter");
            if (!filters.Contains(filter))
                return;
            else
            {
                filter.Pipeline = null;
                filters.Remove(filter);
            }
        }

        /// <summary>
        /// ��ǰ�ܵ��������Ϣ����
        /// </summary>
        public virtual T Message
        {
            get { return message; }
            set { message = value; }
        }

        /// <summary>
        /// ��ǰPipeline������Data Source
        /// </summary>
        public IDataSource<T> DataSource
        {
            get { return dataSource; }
        }

        /// <summary>
        /// ��ǰPipeline������Data Sink
        /// </summary>
        public IDataSink<T> DataSink
        {
            get { return DataSink; }
        }
    }
}
