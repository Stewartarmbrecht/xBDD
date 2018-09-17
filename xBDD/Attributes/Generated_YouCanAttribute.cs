
namespace xBDD
{

	/// <summary>
	/// Defines the reason for a feature.
	/// Should be set on the test class that executes the test methods which are the scenarios.
	/// </summary>
	[System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = false)]
	public class Generated_SoThatAttribute : System.Attribute
	{
		string soThatStatement;
			
		/// <summary>
		/// Sets the reason for a feature.
		/// </summary>
		/// <param name="soThatStatement">The </param>
		public Generated_SoThatAttribute(string soThatStatement)
		{
			this.soThatStatement = soThatStatement;
		}
	
		/// <summary>
		/// Returns the statement that captures the benefit
		/// of the feature.
		/// </summary>
		/// <returns>Benefit statement.</returns>
		public string GetSoThatStatement()
		{
			return soThatStatement;
		}
	}
}
