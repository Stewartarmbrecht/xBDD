namespace xBDD
{

	/// <summary>
	/// Captures the capability statement for a feature.
	/// This attribute should be added to the test class for a feature.
	/// </summary>
	[System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = false)]
	public class Generated_ByAttribute : System.Attribute
	{
		string capabilityStatement;
		
		/// <summary>
		/// Sets the capability statement for a feature.
		/// </summary>
		/// <param name="capabilityStatement">
		/// Single statement that captures the capability that a feature provides.
		/// </param>
		public Generated_ByAttribute(string capabilityStatement)
		{
			this.capabilityStatement = capabilityStatement;
		}
	
		/// <summary>
		/// Gets the capability statement for a feature.
		/// </summary>
		/// <returns>Capability statement.</returns>
		public string GetCapabilityStatement()
		{
			return capabilityStatement;
		}
	}
}
