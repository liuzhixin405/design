using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Description;
using Common;
using Server;
namespace WebServiceGateway.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Server";
            QuoteService service = new QuoteService();
            Uri uri = new Uri("http://localhost:20000");
            using (ServiceHost host = new ServiceHost(service, uri))
            {
                Console.WriteLine("Service started ...");
                BasicHttpBinding binding = new BasicHttpBinding();
                ServiceEndpoint endPoint = host.AddServiceEndpoint
                    (typeof(Common.IQuote), binding, "Server");
                endPoint.Behaviors.Add(new QuoteFilterBehaviour());
                host.Open();
                Console.ReadLine();
            }
        }
    }
}
