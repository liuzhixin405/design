using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.ProxyPattern.Remote.Client
{
    class Program
    {
        public static void Main()
        {
            using (UserClient client = new UserClient())
            {
                Console.WriteLine(client.Greeting("joe"));
                Console.WriteLine("Press any key to stop");
                Console.ReadLine();
            }
        }
    }
}
