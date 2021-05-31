using System;
using System.Collections.Generic;
using System.ServiceModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Client;
namespace MarvellousWorks.PracticalPattern.WebServiceDIP.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            using (QuoteClient client = new QuoteClient())
            {
                Console.WriteLine("Press any key when service started ...");
                Console.ReadLine();
                string id = "quote:2007-07-15";
                Quote quote = client.GetQuote(id);
                Assert.AreEqual<string>(id, quote.Id);
                Console.WriteLine(quote.Id);
                Console.ReadLine();
            }
        }
    }
}
