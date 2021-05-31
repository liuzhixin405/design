using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.WebServiceDTO.Client.InvokePattern
{
    /// <summary>
    /// 需要通过多次调用生产者服务“拼凑”的消息。
    /// </summary>
    struct Quote
    {
        public struct QuoteItem
        {
            public string ProductId;
            public double UnitPrice;
        }

        public string Id;
        public string Company;
        public QuoteItem[] Items;
    }
}
