namespace xBDD.Browser
{
	public class PageLocation
	{
		public PageLocation(string description, string url)
		{
			Description = description;
			Url = url;
		}
		public string Description { get; private set; }
		public string Url { get; private set; }
	}
}