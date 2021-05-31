using System;
using System.Collections.Generic;
using System.ServiceModel;
using Server;
namespace MarvellousWorks.PracticalPattern.WebServiceDIP.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(QuoteService)))
            {
                host.Open();
                Console.WriteLine("Service started ...");
                Console.ReadLine();
            }
        }
    }
}
