using System.Collections.Generic;
using System.Linq;
using xBDD.Model;

namespace xBDD.Core
{
	public class AreaCache
	{
		CoreFactory factory;
		List<Area> areas;
		public AreaCache(CoreFactory factory)
		{
			this.factory = factory;
			this.areas = new List<Area>();
		}
		
		public Area GetOrCreate(TestRun testRun, string areaPath)
		{
			var area = areas.Where(x => x.Name == areaPath).FirstOrDefault();
			if(area == null)
			{
				area = factory.CreateArea(areaPath, testRun);
				areas.Add(area);				
			}
			return area;
		}
	}
}