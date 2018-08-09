using System.Collections.Generic;
using System.Linq;
using xBDD.Model;

namespace xBDD.Core
{
	internal class AreaCache
	{
		CoreFactory factory;
		List<Area> areas;
		internal AreaCache(CoreFactory factory)
		{
			this.factory = factory;
			this.areas = new List<Area>();
		}
		
		internal Area GetOrCreate(TestRun testRun, string areaName)
		{
			var area = areas.Where(x => x.Name == areaName).FirstOrDefault();
			if(area == null)
			{
				area = factory.CreateArea(areaName, testRun);
				areas.Add(area);				
			}
			return area;
		}
	}
}