namespace xBDD.Browser
{
	public class PageElement
	{
		public PageElement(string description, string selector)
		{
			Description = description;
			Selector = selector;
		}
		public string Description { get; set; }
		public string Selector { get; set; }
	}
}