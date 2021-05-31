using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.PipelinePattern.Push;
namespace MarvellousWorks.PracticalPattern.PipelinePattern.Test.Push
{
    [TestClass]
    public class TestPipeline
    {
        /// <summary>
        /// ����Message����
        /// </summary>
        public class Message : IMessage
        {
            public string Data;
        }

        /// <summary>
        /// ����Filter����
        /// </summary>
        public class AppendAFilter : FilterBase<Message>
        {
            public override Message Handle(Message message)
            {
                message.Data += "A";
                return message;
            }
        }
        public class AppendBFilter : FilterBase<Message>
        {
            public override Message Handle(Message message)
            {
                message.Data += "B";
                return message;
            }
        }

        /// <summary>
        /// ����Data Source����
        /// </summary>
        public class DataSource : IDataSource<Message>
        {
            public virtual Message Read()
            {
                Message message = new Message();
                message.Data = Environment.MachineName;
                return message;
            }
        }

        /// <summary>
        /// ����Data Sink����
        /// </summary>
        public class DataSink : IDataSink<Message>
        {
            public string Content;
            public void Write(Message message)
            {
                Content = message.Data;
            }
        }

        /// <summary>
        /// �����Pipeline����
        /// </summary>
        public class Pipeline : PipelineBase<Message>
        {
            public Pipeline(IDataSource<Message> dataSource, IDataSink<Message> dataSink)
            {
                Add(new AppendAFilter());
                Add(new AppendBFilter());

                this.dataSource = dataSource;
                this.dataSink = dataSink;
            }

            public override void Process()
            {
                this.message = dataSource.Read();
                base.Process();
            }
        }

        [TestMethod]
        public void Test()
        {
            IDataSource<Message> dataSource = new DataSource();
            IDataSink<Message> dataSink = new DataSink();
            PipelineBase<Message> pipeline = new Pipeline(dataSource, dataSink);
            pipeline.Process();
            Assert.AreEqual<string>(Environment.MachineName + "AB",
                pipeline.Message.Data);
        }
    }
}
