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
		
		internal Feature GetOrCreate(Capability capability, string name, CodeDetails codeDetails)
		{
			var feature = features.Where(x => x.Name == name && x.Capability == capability).FirstOrDefault();
			if(feature == null)
			{
				feature = factory.CreateFeature(name, capability);
				if(codeDetails != null)
				{
					feature.AsA = codeDetails.GetFeatureAsAStatement();
					feature.YouCan = codeDetails.GetFeatureYouCanStatement();
					feature.SoThat = codeDetails.GetFeatureSoThatStatement();
					feature.FullClassName = codeDetails.GetFullClassName();
					feature.Explanation = codeDetails.GetFeatureExplanation();
					feature.ExplanationFormat = codeDetails.GetFeatureExplanationFormat();
					feature.Assignments = codeDetails.GetFeatureAssignments();
					feature.Tags = codeDetails.GetFeatureTags();
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