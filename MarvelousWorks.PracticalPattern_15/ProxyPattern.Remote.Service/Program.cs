using System;
using System.Collections.Generic;
using System.ServiceModel;
using MarvellousWorks.PracticalPattern.ProxyPattern.Remote.Common;
namespace Service
{
    /// <summary>
    /// ����Э��
    /// </summary>
    [ServiceContract(Namespace = "http://marvellousWorks.practicalPattern/proxyPattern/remote")]
    public interface IUser
    {
        [OperationContract]
        string Greeting(string userName);
    }

    /// <summary>
    /// ����˶Է���Э��ľ���ʵ����
    /// </summary>
    public class UserService : IUser
    {
        public string Greeting(string userName)
        {
            RemoteConfigurationSection<string> config = new RemoteConfigurationSection<string>();
            foreach (ProcessHandler<string> process in config.PostProcess)
                userName = process(userName);
            string result = "Hello " + userName;
            foreach (ProcessHandler<string> process in config.PreProcess)
                result = process(result);
            return result;
        }
    }

    public class Program
    {
        public static void Main()
        {
            using (ServiceHost host = new ServiceHost(typeof(UserService)))
            {
                host.Open();
                Console.WriteLine("Service started ...");
                Console.ReadLine();
            }
        }
    }
}
