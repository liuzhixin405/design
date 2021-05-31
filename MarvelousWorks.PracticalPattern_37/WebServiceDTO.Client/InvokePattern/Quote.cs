using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.WebServiceDTO.Client.InvokePattern
{
    /// <summary>
    /// ��Ҫͨ����ε��������߷���ƴ�ա�����Ϣ��
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
