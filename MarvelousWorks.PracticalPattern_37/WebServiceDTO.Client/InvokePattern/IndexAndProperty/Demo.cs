using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.WebServiceDTO.Client.InvokePattern.IndexAndProperty
{
    /// <summary>
    /// ͨ��Property + Indexer ��ʽʵ�ֵ�DTO ������ʽ��
    /// </summary>
    class DataTransferObjectA
    {
        protected Quote quote;

        public string Id
        {
            get { return quote.Id; }
            set { quote.Id = value; }
        }

        public string Company
        {
            get { return quote.Company; }
            set { quote.Company = value; }
        }

        public Quote.QuoteItem this[int index]
        {
            get { return quote.Items[index]; }
            set { quote.Items[index] = value; }
        }
    }

}


