namespace MySample.Features.Capability2SkippedUntested.SubCapability1Passing
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	[TestClass]
	[AsA("User")]
	[SoThat("you can derive some value")]
	[YouCan("doing something")]
	[Explanation(@"
		<html>
			<body>
				<h1>Feature Html Explanation</h1>
				<p>
					You can also use raw html to explain a scenario that will
					be rendered in an iframe.
				</p>
			</body>
		</html>",2,TextFormat.htmlpreview)]
	[Assignments("FeatureAssignment1","FeatureAssignment2")]
	[Tags("FeatureTag1","FeatureTag2")]
	public partial class Feature1Passing: xBDDFeatureBase
	{

		[TestMethod]
		[Explanation(@"
			<html>
				<body>
					<h1>Scenario Html Explanation</h1>
					<p>
						You can also use raw html to explain a scenario that will
						be rendered in an iframe.
					</p>
				</body>
			</html>",3,TextFormat.htmlpreview)]
		[Assignments("ScenarioAssignment1","ScenarioAssignment2")]
		[Tags("ScenarioTag1","ScenarioTag2")]
		public async Task Scenario1Passing()
		{
			await xB.AddScenario(this, 1000)
				.Given("Step 1 Passing With Explanation And Input",
					(s) => { 
						// Enter your code here.
					},
					@"
						Here 
						is some multiline
						input".RemoveIndentation(6,true),
					TextFormat.text,
					@"
						# Step 1 Explanation
						This is my step 1 explanation.".RemoveIndentation(6,true))
				.When("Step 2 Passing With Output",
					(s) => { 
						s.Output = "Here is some output text that is a single line.";
						s.OutputFormat = TextFormat.text;
					})
				.Then("Step 3 Passing With Html Preview Output",
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
					}, @"
						<html>
							<body>
								<h1>Step Html Input</h1>
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
						</html>".RemoveIndentation(6,true), TextFormat.htmlpreview,
						@"
						<html>
							<body>
								<h1>Step Html Explanation</h1>
								<p>
									You can also use raw html for the explanation.
								</p>
								<h2>Use Cases:</h2>
								<ol>
									<li>Rendering the HTML page at a given state. So that you can interact with it in the results.</li>
									<li>Rendering a table of the results if you need to.</li>
									<li>Rendering a part of the web page.</li>
									<li>Including a link to a point in the application.</li>
								</ol>
							</body>
						</html>".RemoveIndentation(6,true), TextFormat.htmlpreview)
				.And("Step 4 Passing With Markdow for Input, Output and Explanation",
					(s) => { 
						s.Output = @"
						### Output With Markdown
						You can use markdown to draft up your input.
						Here is an html table.  You could generate this in your code.


						xBDD input and output are about communication that you generate from code.
						It's not intended serve as actual input.


						| Col 1   | Col 2    | Col 3    |
						|---------|----------|----------|
						| This    | is a     | table    |
						| You can | add rows | via code |


						".RemoveIndentation(6, true);
						s.OutputFormat = TextFormat.markdown;
					},@"
						### Input With Markdown
						You can use markdown to draft up your input.
						Here is an html table.  You could generate this in your code.

						xBDD input and output are about communication that you generate from code.
						It's not intended serve as actual input.


						| Col 1   | Col 2  | Col 3    |
						|---------|--------|----------|
						| This | is a | table |
						| You can | add rows | via code |


						".RemoveIndentation(6, true), TextFormat.markdown, 
					@"
						### Step Explanation
						You can also provide an explanation for a step in your code.
						This will also take markdown.".RemoveIndentation(6, true))
				.Run();
		}
	}
}