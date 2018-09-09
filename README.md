# xBDD
xBDD is a Behavior Driven Development framework that runs inside the testing framework of your choice (eventually, currently only running in MSTest :) ) and 
provides the following key features:
1. Streamlined UI and API Testing Framework
2. Product Documentation Generator
3. Development Progress Reporting (Backlog and WIP Visibility)

When connected to xBDD's online services, this framework will also provide:
1. Product Development Flow Dashboards
3. Product Planning and Collaboration Workspaces
4. Feature Utilization and Performance Monitoring System
*THIS ONLINE SERVICE HAS YET TO BE DEVELOPED*

This project is currently being built.  The objectives for it are changing as it is built.  Here is the current list of goals:

## Goals

### Streamlined UI and API Testing
1. **Common UI Step Library** - Provide a simple set of pre-built steps that enable the rapid development of UI automation tests
on top of a headless Selenium chrome webdriver.
2. **Common API Step Library** - Provide a simple set of pre-build steps that enable the rapid development of 
template-based, automated API tests. 
1. **Custom Step Resuse** - The framework should encourage/simplify the development of custom step libraries that streamline
the process of building future tests.
3. **Intellisense Discovery** - A developer should be able to easily find existing steps using the standard intellisense
features included in Visual Studio, VS Code, or other IDEs.
4. **Testing Platform Agnostic** - This framework should be usable
in any testing platform that supports .Net code.
1. **DotNet Core (Cross Platform) Capable** - Capable of running where ever dotnet core can run.
2. **Hybrid Asynchronous Support** - You can define scenarios that run both synchronous and asynchronous steps.
2. **Lanugage Portable** - We are organizing it's own testing library so that reusing the tests on a ported 
xBDD instance (like to JavaScript) will be possible.

### Product Documentation
1. **Gherkin Style Output** - Test runs will generate information that can be used to build reports 
that can be shared with a non-developer to explain how the system has been designed to meet the user need.
2. **Advanced Html Reports** - Out of the box, xBDD will provide graphically pleasing reports from a test run 
that can be used as documentation/training for the application as well as report on development progress.
2. **Database Accessible** - Ability to publish test passes to a database to allow for enhanced reporting
and serve as a basis for showing product growth/progress over time.

## Sample Report
This project is being used to test itself.  The goal is that the reports from the test results will ultimately 
serve as documentation and training materials.  The current reports (as well as the organization of features
and scenarios) is a long ways from accomplishing this.  However, you can see thier current state now.  Just 
keep in mind that some are disorganized, will be rewritten, and will likely look very different once the 
initial version of this platform is released.

*__Note:__ Area, Feature, and Scenario names will expand when clicked.*

### SUMMARY

* [xBDD Features Summary](https://rawgit.com/Stewartarmbrecht/xBDD/master/xBDD.Features.Summary.GitHub.html) - Features for generating reports.

### Active Focus

* [Generating Code](https://rawgit.com/Stewartarmbrecht/xBDD/master/xBDD.Features.GeneratingCode/test-results/xBDD.Features.Generatingcode.html) - Features for generating solutions (with multiple test projects), test projects and features.

* [Generating Reports](https://rawgit.com/Stewartarmbrecht/xBDD/master/xBDD.Features.GeneratingReports/test-results/xBDD.Features.GeneratingReports.Results.html) - Features for generating reports.

### Features To Be Defined (Links will return 404)

* [Defining Features](https://rawgit.com/Stewartarmbrecht/xBDD/master/xBDD.Features.DefiningFeatures/test-results/xBDD.Features.DefiningFeatures.Results.html) - Features for defining features, scenarios, and steps.

* [Automating UI Testing](https://rawgit.com/Stewartarmbrecht/xBDD/master/xBDD.Features.AutomatingUITesting/test-results/xBDD.Features.AutomatingUITesting.Results.html) - Features for running browser automation tests.

* [Streamlining API Testing](https://rawgit.com/Stewartarmbrecht/xBDD/master/xBDD.Features.StreamliningAPITesting/test-results/xBDD.Features.StreamliningAPITesting.Results.html) - Features for testing an API.

* [Running Scenarios](https://rawgit.com/Stewartarmbrecht/xBDD/master/xBDD.Features.RunningScenarios/test-results/xBDD.Features.RunningScenarios.Results.html) - Features for running filtered sets of scenarios.

### Sample

* [MySample.Features](https://rawgit.com/Stewartarmbrecht/xBDD/master/Legacy/MySample.Features/test-results/MySample.Features.Results.All.FullSorted.html) - Set of tests defined in a sample project used for testing xBDD.

### Old Tests (to be replaced)

* [Legacy Features](https://rawgit.com/Stewartarmbrecht/xBDD/master/Legacy/xBDD.Features/test-results/xBDD.Features.Results.html) - Old set of tests to be replaced by the following projects.  WARNING MULTIPLE FAILING TESTS WITH CAPTURED OUTPUT IS CAUSING EXTEMELY SLOW RESPONSE TIMES IN THE BROWSER.

## Getting Started

### MSTest Setup

1. Install the dotnet xbdd tools...

        dotnet tool install --global dotnet-xbdd --version 0.0.8-alpha

2. Create a directory for your test project and open your terminal in that project.
3. Create the test project...

        dotnet xbdd project generate MSTest

4. Run the test and the test will pass...
    
        dotnet test

5. Review the code to see how it works. If you have vscode installed...

        code .
