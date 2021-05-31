using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Runtime.Serialization;
namespace Common
{
    #region ���ݽṹ�Ķ���
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

    #region ����ӿڵĶ���
    [ServiceContract]
    public interface IQuote
    {
        [OperationContract]
        Quote GetQuote(string id);
    }
    #endregion
}