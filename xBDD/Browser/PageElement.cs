namespace xBDD.Browser
{
	/// <summary>
	/// Holds identifying information about a page element.
	/// </summary>
	public class PageElement
	{
		/// <summary>
		/// Creates a new page element.
		/// </summary>
		/// <param name="description">The description to use in step names.</param>
		/// <param name="selector">The CSS selector to use to find the element.</param>
		public PageElement(string description, string selector)
		{
			Description = description;
			Selector = selector;
		}
		/// <summary>
		/// Gets the description of the page element.
		/// </summary>
		/// <value></value>
		public string Description { get; set; }
		/// <summary>
		/// Gets the CSS selector used to find the element on a page.
		/// </summary>
		/// <value></value>
		public string Selector { get; set; }
	}
}