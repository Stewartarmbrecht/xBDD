namespace xBDD.Features.GeneratingCode.GeneratingProjectFiles
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	[TestClass]
	[AsA("Developer")]
	[YouCan("generate a new MS Test Project")]
	[By("executing the 'dotnet xbdd project generate MSTest' command")]
	[Explanation(@"
		## xBDD Tools
		
		You can install a command line utility that will help you generate a dotnet core test project with a file structure that will help you follow best practices for when building your tests.  All you need is an empty directory that you want to create a new project within.  The xBDD framework will create the following files in the directory:
		
		## Project Files
		
		1. **[FolderName].csproj** - If a project file does not already exist, xBDD will create a csproj file with the same name as the folder you are initializing the project within.  The project file will contain all the necessary references to develop xBDD features.  This file will not be overwritten if it already exists.
		2. **[FolderName].csproj.xBDD** - xBDD will also create an identical project file that ends in .xbdd that it will continue to update each time you execute the `dotnet xbdd project generate MSTest` command.  You can use this file to update your project file in the future if xBDD makes any changes to the default project file.
		3. **TestInitializeAndComplete.xbdd.cs** - This class handles the test initialize and cleanup operations for xBDD.  If you already implement these methods in your project, comment out the `[AssemblyInitialize]` and `[AssemblyCleanup]` attributes and call the `TestRunStart()` and `TestRunComplete` methods from your code where you have implemented the respective attributes.  The `TestRunStart` method initializes the web browser to either display or not display.  The `TestRunComplete` method ensures that the webdriver is disposed and generates standard reports for a test run.
		4. **xBDDConfig.json** - Use this config file to override default values for xBDD settings.
		5. **xBDDFeatureBase.xbdd.cs** - This is the base class you should use for creating features. It is not required but if you inherit from this class you will not need to implement the iFeature interface or manually inject an iOutputWriter into each scenario.  The output writer is used by xBDD to write output to the testing framework during execution.  This helps with printing out scenario and exception details when a step fails.  When scenarios run in a test class that implements the iFeature interface, the output writer is automatically injected into the scenario when it is run.  Without implementing the iFeature interface, you need to explicity set the output writer for each scenario.  The xBDDFeatureBase class implements both the iFeature and iOutputWriter interface so that all you need to do is inherit from this class and all scenarios will automatically log details to the underlying testing framework (MSTest).
		6. **xBDDFeatureSort.cs** - This class is used to create a sorted list of features names that can be passed to a test run object to sort the scenarios prior to running a report.  This class is only written once by the framework.  If it already exists it will not be overwritten.
		7. **xBDDFeatureSort.xbdd.cs** - This class is a duplicate of the `xBDDFeatureSort.cs` class and is recreated each time you generate code.  It is created so that you can copy missing features into the `xBDDFeatureSort.cs` class. 
		8. **xBDDReasonSort.cs** - This class is used to cascade the reasons up from scenarios, to features, to areas, to the test run.  The sort order controls the order of precedence from least to most.  For example if two features have reasons A and B and the ReasonSort places A before B then the parent area for both features will have a reason of B.
		9. **xBDDReasonSort.xbdd.cs** - This class is a duplicate of the `xBDDReasonSort.cs` class and is recreated each time you generate code.  It is created so that you can copy missing reasons into the `xBDDFeatureSort.cs` class. 
		10. **xBDDFeatureImport.txt** - A text document that you can use to outline the areas, features, scenarios, and steps to import into the project.  This document can use either tabs or spaces for indentation as long as it is consistent.  You can also paste the text format for Workflowy outlines into this file and the dashes will be automatically removed.
		11. **Features/MySampleArea/MySampleFeature.cs** - A sample feature for the project to execute.
		
		## Standard Reports
		
		The standard xBDD project is setup to generate a standard set of reports when you run the tests in the test project.  These include:
		1. **Html Test Run Report** - Provides an outline view of the test results with outcome statics at each level.
		2. **JSON Test Run Report** - A Json serialization of the Test Run object.  The test run object is the foundation for all reports.  The Json test run report can be used to hydrate a test run to build any other report.
		3. **Text Test Run Report** - Provides a text indentation outline of the test run including step inputs, outputs and exceptions.
		5. **OPML Outline Report** - An Outline Processor Markup Language representation of the test run results.  This can be used to copy features back into Workflowy.",2)]
	public partial class GeneratingANewMSTestProject: xBDDFeatureBase
	{

    }
}
