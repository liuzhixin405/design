using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.ChainOfResponsibilityPattern.Configuration
{
    /// <summary>
    /// «Î«Û∂‘œÛ
    /// </summary>
    public class Request
    {
        private double price;
        private PurchaseType type;

        public Request(double price, PurchaseType type) 
        {
            this.price = price; this.type = type; 
        }

        public double Price { get { return price; } set { price = value; } }
        public PurchaseType Type { get { return type; } set { type = value; } }
    }
}
