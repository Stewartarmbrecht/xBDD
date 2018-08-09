# xBDD
xBDD is a Behavior Driven Development framework that runs inside the testing framework of your choice and 
provides the following key features:
1. Streamlined UI and API Testing Framework
2. Product Documentation Generator

When connected to xBDD's online services, this framework can also provide:
1. Product Development Monitoring Dashboards
3. Product Planning and Collaboration Workspaces
4. Feature Utilization and Performance Monitoring System

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

Note: Area, Feature, and Scenario names will expand when clicked.


1. [xBDD.Core.Test](https://rawgit.com/Stewartarmbrecht/xBDD/master/core/xBDD.Features/test-results/xBDD.Features.Results.html) - Writing and running scenarios.
2. [xBDD.Reporting.Test](https://rawgit.com/Stewartarmbrecht/xBDD/master/reporting/xBDD.Features/test-results/xBDD.Features.Results.html) - Generating reports from a test run.
3. [xBDD.Reporting.Database.Test](https://rawgit.com/Stewartarmbrecht/xBDD/master/reporting.database/xBDD.Reporting.Database.Test/test-results/xBDD.Features.Results.html) - Writing test results to a database.
4. [xBDD.Features](https://rawgit.com/Stewartarmbrecht/xBDD/master/shared/xBDD.Features/test-results/xBDD.Features.Results.html) - Features of the project (environment setup and what not).

## Getting Started

### MSTest Setup

#### Run a Test

1. Setup a MS Test project (or open one you already have).  Use [this](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-mstest) link for instructions.
2. Add a reference to the xBDD nuget package.

        dotnet add package xBDD.Core

3. Add the following test class.

        using Microsoft.VisualStudio.TestTools.UnitTesting;
        using System.Threading.Tasks;
        using System.Collections.Generic;
        using xBDD;

        namespace xBDD.SampleApp.Test.Features.HomePage
        {
            [InOrderTo("know how many items are in a List<T>")]
            [AsA("Developer")]
            [IWouldLikeTo("use a Count property on the list object.")]
            [TestClass]
            public class GenericListCount
            {
                [TestMethod]
                public async Task CallWhenPopulated()
                {
                    List<string> list = new List<string>();
                    int? count = -1;
                    await xB.CurrentRun
                        .AddScenario(this)
                        .Given("A generic list of type string with two string in it", (s) => {
                            list.Add("String 1");
                            list.Add("String 2");
                        })
                        .When("I call the Count property", (s) => {
                            count = list.Count;
                        })
                        .Then("the return value should be 2;", (s) => {
                            Assert.AreEqual(2, count);
                        })
                        .Run();
                }
            }
        }

4. Run the test and the test will pass.
    
        dotnet test

5. Modify the test to fail and view the output.  Do this by commenting out the list.add("String 2"); line.  When you run the test you should see.

        Starting test execution, please wait...
        Failed   xBDD.SampleApp.Test.Features.HomePage.GenericListCount.CallWhenPopulated
        Error Message:
        Test method xBDD.SampleApp.Test.Features.HomePage.GenericListCount.CallWhenPopulated threw exception:
        xBDD.StepException: The step 'the return value should be 2;' threw a 'AssertFailedException' exception with a message: 'Assert.AreEqual failed. Expected:<2>. Actual:<1>. '. See the inner exception for details. ---> Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException: Assert.AreEqual failed. Expected:<2>. Actual:<1>.
        Stack Trace:
        --StackTrace Omitted--
        
        Standard Output Messages:


        Debug Trace:
        Call When Populated
            Given A generic list of type string with two string in it
            When I call the Count property
            Then the return value should be 2;


        Total tests: 1. Passed: 0. Failed: 1. Skipped: 0.
        Test Run Failed.
        Test execution time: 1.2571 Seconds

#### Save Test Results to a Text File



