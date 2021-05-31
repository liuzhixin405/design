using System;
using System.Collections.Generic;
using System.ServiceModel;
using Common;
namespace Server
{
    /// <summary>
    /// 具体实现服务的类型
    /// </summary>
    public class QuoteService : IQuote
    {
        public Quote GetQuote(string id)
        {
            #region 填充测试数据
            Quote quote = new Quote();
            quote.Id = id;
            quote.Company = "MarvellousWorks";

            QuoteItem[] items = new QuoteItem[2];
            items[0] = new QuoteItem();
            items[0].ProductID = 1;
            items[0].Price = 220;
            items[0].QuantitiveInStock = 10;
            items[1] = new QuoteItem();
            items[1].ProductID = 2;
            items[1].Price = 3.4;
            items[1].QuantitiveInStock = 3000;
            quote.Items = items;
            #endregion

            return quote;
        }
    }
}
