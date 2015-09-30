using System.Collections.Generic;
using System.Linq;
using xBDD.Model;

namespace xBDD.Core
{
	public class FeatureCache
	{
		CoreFactory factory;
		List<Feature> features;
		public FeatureCache(CoreFactory factory)
		{
			this.factory = factory;
			this.features = new List<Feature>();
		}
		
		public Feature GetOrCreate(Area area, string name)
		{
			var feature = features.Where(x => x.Name == name && x.Area == area).FirstOrDefault();
			if(feature == null)
			{
				feature = factory.CreateFeature(name, area);
				features.Add(feature);				
			}
			return feature;
		}
	}
}