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
		
		internal Feature GetOrCreate(Area area, string name, CodeDetails codeDetails)
		{
			var feature = features.Where(x => x.Name == name && x.Area == area).FirstOrDefault();
			if(feature == null)
			{
				feature = factory.CreateFeature(name, area);
				if(codeDetails != null)
				{
					feature.Actor = codeDetails.GetFeatureActorName();
					feature.Capability = codeDetails.GetFeatureActorAction();
					feature.Value = codeDetails.GetFeatureActorValue();
					feature.FullClassName = codeDetails.GetFullClassName();
					feature.Explanation = codeDetails.GetFeatureExplanation();
				}
				features.Add(feature);				
			}
			return feature;
		}

		internal Feature GetByFullClassName(string featureFullName)
		{
			return features.Where(feature => {
				return feature.FullClassName == featureFullName;
			}).FirstOrDefault();
		}

		internal List<Feature> GetAllFeatures()
		{
			return this.features;
		}
	}
}