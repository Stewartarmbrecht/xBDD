namespace xBDD.Browser
{
	/// <summary>
	/// Keeps a description and URL 
	/// of a web location.
	/// </summary>
	public class PageLocation
	{
		/// <summary>
		/// Creates a new instance of a PageLocation object.
		/// </summary>
		/// <param name="description">The description of the location to add to step names.</param>
		/// <param name="url">The URL of the page.</param>
		public PageLocation(string description, string url)
		{
			Description = description;
			Url = url;
		}
		/// <summary>
		/// Gets the description of the page location.
		/// </summary>
		/// <value>The description fo the page location.</value>
		public string Description { get; private set; }
		/// <summary>
		/// Gets the Url of the page location.
		/// </summary>
		/// <value>The URL for the page location.</value>
		public string Url { get; private set; }
	}
}