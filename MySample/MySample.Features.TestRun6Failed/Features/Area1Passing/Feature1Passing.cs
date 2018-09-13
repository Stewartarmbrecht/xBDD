namespace MySample.Features.TestRun6Failed.Area1Passing
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	[TestClass]
	[AsA("User")]
	[YouCan("derive some value")]
	[By("performing some action")]
	[Explanation(@"
		# Explanation of Feature
		In addition to the feature statement, you can create a markdown 
		explanation of the feature and include as much documentation as you would like.
		You could also link off to another markdown file if you would like.
		
		## Markdown List

		* List Item 1
		* List Item 2
		* List Item 3
		",2)]
	[Assignments("Blue Team","John Product Owner")]
	[Tags("Feature Tag 1", "Feature Tag 2")]
	public partial class Feature1Passing: xBDDFeatureBase
	{

		[TestMethod]
		[Explanation(@"
			# Explanation of Scenario
			You can also add documentation to a scenario.",3)]
		[Assignments("Jane Developer")]
		[Tags("Scenario Tag 1", "Scenario Tag 2")]
		public async Task Scenario1Passing()
		{
			await xB.AddScenario(this, 1000)
				.Given("Step 1 Passing",
					(s) => { 
						s.Output = @"
							<html>
								<body>
									<h1>Step Html Output</h1>
									<p>
										You can also output raw html that will
										be rendered in an iframe.
									</p>
									<h2>Use Cases:</h2>
									<ol>
										<li>Rendering the HTML page at a given state. So that you can interact with it in the results.</li>
										<li>Rendering a table of the results if you need to.</li>
										<li>Rendering a part of the web page.</li>
										<li>Including a link to a point in the application.</li>
									</ol>
								</body>
							</html>".RemoveIndentation(7,true);
						s.OutputFormat = TextFormat.htmlpreview;
					},@"
						You can also 
						Add multi-line text 
						That explains or represnts the input 
						to the step. This text can be formatted to any code language
						suppored by google pretty print. You can also use raw html
						like in the output.".RemoveIndentation(6, true), TextFormat.text, 
					@"
						# Step Explanation
						You can also provide an explanation for a step in your code.
						This will also take markdown.".RemoveIndentation(6, true))
				.When("Step 2 Passing",
					(s) => { 
						// Enter your code here.
					})
				.Then("Step 3 Passing",
					(s) => { 
						// Enter your code here.
					})
				.Run();
		}

	}
}