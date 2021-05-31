using System;
using System.Collections.Generic;
using System.Text;

namespace MarvellousWorks.PracticalPattern.WebServiceDTO.Client.InvokePattern.Setter
{

    /// <summary>
    /// 通过Get() + Set() 方式实现的DTO 操作方式。
    /// </summary>
    class DataTransferObjectB
    {
        protected Quote quote;

        public string GetId()
        {
            return quote.Id;
        }

        public string GetCompany()
        {
            return quote.Company;
        }

        public void SetId(string id)
        {
            quote.Id = id;
        }

        public void SetCompany(string company)
        {
            quote.Company = company;
        }

        public double GetUnitPrice(int index)
        {
            return quote.Items[index].UnitPrice;
        }

        public void SetUnitPrice(int index, double unitPrice)
        {
            quote.Items[index].UnitPrice = unitPrice;
        }

        public string GetProductId(int index)
        {
            return quote.Items[index].ProductId;
        }

        public void SetProductId(int index, string productId)
        {
            quote.Items[index].ProductId = productId;
        }
    }


}

