using System;
using System.Collections.Generic;
using Server;
using System.ServiceModel;
namespace WebServiceDTO.Server
{
    class Program
    {
        public static void Main()
        {
            using (ServiceHost host = new ServiceHost(typeof(ContractService)))
            {
                host.Open();
                Console.WriteLine("Service started ...");
                Console.ReadLine();
            }
        }
    }
}
