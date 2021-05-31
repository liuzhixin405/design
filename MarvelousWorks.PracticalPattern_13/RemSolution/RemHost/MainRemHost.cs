#region using
using System;
using System.Runtime.Remoting;
using System.Diagnostics;
#endregion
namespace Test.Rem.Host
{
	public class MainRemHost
	{
		public static void Main(string[] args)
		{
            string configFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
            RemotingConfiguration.Configure(configFile, false);
            Console.WriteLine("Host started and listening ...");
			Console.ReadLine();
		}
	}
}
