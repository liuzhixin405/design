using System;
using System.Collections.Generic;
using System.ServiceModel.Description;
using System.ServiceModel;
using Common;
namespace WebServiceGateway.Client
{
    public class QuoteClient
    {
        public IQuote GetQuote()
        {
            ServiceEndpoint endPoint = new ServiceEndpoint(
                ContractDescription.GetContract(typeof(IQuote)), 
                new BasicHttpBinding(), 
                new EndpointAddress("http://localhost:20000/server"));
            ChannelFactory<IQuote> factory = new ChannelFactory<IQuote>(endPoint);
            factory.Endpoint.Behaviors.Add(new QuoteFilterBehaviour());
            return factory.CreateChannel();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press any key when service started ...");
            Console.Title = "Client";
            IQuote quoteService = new QuoteClient().GetQuote();
            Quote quote = quoteService.GetQuote("20");
            Console.WriteLine(quote.Company);
            Console.ReadLine();
        }
    }
}
