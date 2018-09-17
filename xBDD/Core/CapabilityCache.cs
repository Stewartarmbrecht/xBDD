using System.Collections.Generic;
using System.Linq;
using xBDD.Model;

namespace xBDD.Core
{
	internal class CapabilityCache
	{
		CoreFactory factory;
		List<Capability> capabilities;
		internal CapabilityCache(CoreFactory factory)
		{
			this.factory = factory;
			this.capabilities = new List<Capability>();
		}
		
		internal Capability GetOrCreate(TestRun testRun, string capabilityName)
		{
			var capability = capabilities.Where(x => x.Name == capabilityName).FirstOrDefault();
			if(capability == null)
			{
				capability = factory.CreateCapability(capabilityName, testRun);
				capabilities.Add(capability);				
			}
			return capability;
		}
	}
}