using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.Serialization;
namespace MarvellousWorks.PracticalPattern.WebServiceAdapter.Test
{
    #region 生产者一方的数据结构的定义
    [DataContract]
    public struct QuoteItem
    {
        [DataMember]
        public int ProductID;

        [DataMember]
        public double Price;

        [DataMember]
        public double QuantitiveInStock;
    }

    [DataContract]
    public struct Quote
    {
        [DataMember]
        public string Id;

        [DataMember]
        public string Company;

        [DataMember]
        public QuoteItem[] Items;
    }
    #endregion

    #region 消费者一方的数据结构定义抽象
    [DataContract]
    public abstract class QuoteTargetBase
    {
        [DataMember]
        public string SequenceNo;

        [DataMember]
        public string CompnayName;

        /// <summary>
        /// 转换工作最实质性的步骤
        /// </summary>
        /// <param name="quote"></param>
        /// <returns></returns>
        public QuoteTargetBase InternalConvert(Quote quote)
        {
            SequenceNo = quote.Id;
            CompnayName = quote.Company;
            return this;
        }
    }
    #endregion

    namespace MethodInvokeMapping
    {
        [DataContract]
        public class QuoteTarget : QuoteTargetBase
        {
            public QuoteTargetBase GetQuote(Quote quote)
            {
                return InternalConvert(quote);
            }
        }
    }

    namespace ConversionOperator
    {
        [DataContract]
        public class QuoteTarget : QuoteTargetBase
        {
            public static implicit operator QuoteTarget(Quote quote)
            {
                QuoteTarget target = new QuoteTarget();
                return (QuoteTarget)target.InternalConvert(quote);
            }
        }
    }

    namespace Mapper
    {
        [DataContract]
        public class QuoteTarget : QuoteTargetBase { }

        public class QuoteMapper
        {
            public QuoteTargetBase To(Quote quote)
            {
                QuoteTarget target = new QuoteTarget();
                return target.InternalConvert(quote);
            }
        }
    }


    [TestClass]
    public class TestDataContractTypeMapping
    {
        private const string QuoteID = "A";
        private const string QuoteCompnary = "X";

        private Quote CreateQuote()
        {
            Quote quote = new Quote();
            quote.Id = QuoteID;
            quote.Company = QuoteCompnary;
            return quote;
        }

        private void Validate(QuoteTargetBase target)
        {
            Assert.IsNotNull(target);
            Assert.AreEqual<string>(QuoteID, target.SequenceNo);
            Assert.AreEqual<string>(QuoteCompnary, target.CompnayName);
        }

        [TestMethod]
        public void TestMethodInvokeMapping()
        {
            MethodInvokeMapping.QuoteTarget target = new MethodInvokeMapping.QuoteTarget();
            QuoteTargetBase data = target.GetQuote(CreateQuote());
            Validate(data);
        }

        [TestMethod]
        public void TestConversionOperator()
        {
            ConversionOperator.QuoteTarget target = CreateQuote();
            Validate(target);
        }

        [TestMethod]
        public void TestMapper()
        {
            Mapper.QuoteMapper mapper = new Mapper.QuoteMapper();
            QuoteTargetBase data = mapper.To(CreateQuote());
            Validate(data);
        }
    }
}
