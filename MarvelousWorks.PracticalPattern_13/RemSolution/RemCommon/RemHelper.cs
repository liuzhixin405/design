#region using
using System;
using System.Runtime.Remoting;

using Test.Rem.Common;
#endregion

namespace Test.Rem.Common
{
	public enum RemClassLocation
	{
		ServerSide,
		ClientSide
	}

	public class RemHelper
	{
		#region constructor
		private RemHelper(){}
		#endregion

		#region public static method
		private static bool ExistServiceType(string typeName, ref string url)
		{
			typeName = typeName.Trim();
			WellKnownServiceTypeEntry[] entries = RemotingConfiguration.GetRegisteredWellKnownServiceTypes();

			for(int i=0; i<entries.Length; i++)
				if(entries[i].TypeName == typeName)
				{
					url = entries[i].ObjectUri;
					return true;
				}

			return false;		//Not found
		}

		private static bool ExistClientType(string typeName, ref string url)
		{
			typeName = typeName.Trim();
			WellKnownClientTypeEntry[] entries = RemotingConfiguration.GetRegisteredWellKnownClientTypes();

			for(int i=0; i<entries.Length; i++)
				if(entries[i].TypeName == typeName)
				{
					url = entries[i].ObjectUrl;
					return true;
				}

			return false;		//Not found
		}

        private static bool TryGetClientType(string typeName, ref string url)
        {
            WellKnownClientTypeEntry[] entries = RemotingConfiguration.GetRegisteredWellKnownClientTypes();
            foreach(WellKnownClientTypeEntry entry in entries)
                if(string.Equals(entry.TypeName, typeName))
                {
                    url = entry.ObjectUrl;
                    return true;
                }
            return false;		//Not found
        }

        public static object CreateWellKnownType(string typeName)
        {
            WellKnownClientTypeEntry[] entries = RemotingConfiguration.GetRegisteredWellKnownClientTypes();
            foreach (WellKnownClientTypeEntry entry in entries)
                if (string.Equals(entry.TypeName, typeName))
                    return Activator.GetObject(Type.GetType(typeName), entry.ObjectUrl);
            return null;
        }

		public static object GetWellKnwonTypeInstance(string typeName, RemClassLocation location)
		{
			bool find = false;
			string url = string.Empty;

			if(location == RemClassLocation.ServerSide)
				find = ExistServiceType(typeName, ref url);
			else if(location == RemClassLocation.ClientSide)
				find = ExistClientType(typeName, ref url);
			else
				find = false;

			if(!find)
				return null;
			else
				return Activator.GetObject(Type.GetType(typeName), url);
		}
		#endregion
	}
}
