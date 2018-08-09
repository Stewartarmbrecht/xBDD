using System.Collections.Generic;
using System.Linq;
using xBDD.Model;
using xBDD.Utility;

namespace xBDD.Core
{
	internal class FeatureCache
	{
		CoreFactory factory;
		List<Feature> features;
		internal FeatureCache(CoreFactory factory)
		{
			this.factory = factory;
			this.features = new List<Feature>();
		}
		
		internal Feature GetOrCreate(Area area, string name, Method method)
		{
			var feature = features.Where(x => x.Name == name && x.Area == area).FirstOrDefault();
			if(feature == null)
			{
				feature = factory.CreateFeature(name, area);
				if(method != null)
				{
					feature.Actor = method.GetFeatureActorName();
					feature.Capability = method.GetFeatureActorAction();
					feature.Value = method.GetFeatureActorValue();
				}
				features.Add(feature);				
			}
			return feature;
		}
	}
}