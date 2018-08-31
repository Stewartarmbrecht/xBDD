
namespace xBDD
{

	/// <summary>
	/// Defines the reason for a feature.
	/// Should be set on the test class that executes the test methods which are the scenarios.
	/// </summary>
	[System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = false)]
	public class Generated_YouCanAttribute : System.Attribute
	{
		string benefitStatement;
			
		/// <summary>
		/// Sets the reason for a feature.
		/// </summary>
		/// <param name="benefitStatement">The </param>
		public Generated_YouCanAttribute(string benefitStatement)
		{
			this.benefitStatement = benefitStatement;
		}
	
		/// <summary>
		/// Returns the statement that captures the benefit
		/// of the feature.
		/// </summary>
		/// <returns>Benefit statement.</returns>
		public string GetBenefitStatement()
		{
			return benefitStatement;
		}
	}
}
