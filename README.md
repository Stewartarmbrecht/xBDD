# xBDD
xBDD is a Behavior Driven Development framework that runs inside the testing framework of your choice.
(currently only tested on xUnit)

This project is currently being built.  The objectives for it are changing as it is built.  Here is the current list of goals:

## Goals

1. **Gherkin Style Output** - Test runs will generate information that can be used to build reports 
that can be shared with a non-developer to explain how the system has been designed to meet the user need.
2. **Advanced Html Reports** - Out of the box, xBDD will provide graphically pleasing reports from a test run 
that can be used as documentation/training for the application as well as report on development progress.
2. **Database Accessible** - Ability to publish test passes to a database to allow for enhanced reporting
and serve as a basis for showing product growth/progress over time.
3. **Historical Reports** - xBDD will include a reporting server that can run off of the test results database
to allow for advanced analytics about the teams development effort.
3. **Step Resuse** - The framework should encourage/simplify the development of step libraries that streamline
the process of building future tests.
4. **Intellisense Discovery** - A developer should be able to easily find existing steps using intellisense.
5. **Universal .Net Test Platform Integration** - While named similar to xUnit this framework should be usable
in any testing platform that supports .Net code.  (Right now it's only DNX supported)
6. **DNX Capable** - Capable of running where ever the cross platform .Net framework can.
4. **Hybrid Asynchronous Support** - You can define scenarios that run both synchronous and asynchronous steps.

## Sample Report
This project is being used to test itself.  The goal is that the reports from the test results will ultimately 
serve as documentation and training materials.  The current reports (as well as the organization of features
and scenarios) is a long ways from accomplishing this.  However, you can see thier current state now.  Just 
keep in mind that some are disorganized, will be rewritten, and will likely look very different once the 
initial version of this platform is released.

Note: Area, Feature, and Scenario names will expand when clicked.


1. [xBDD.Core.Test](https://rawgit.com/Stewartarmbrecht/xBDD/master/xBDD/test/xBDD.Core.Test/xBDD.Core.Test.TestResults.html) - Writing and running scenarios.
2. [xBDD.Reporting.Test](https://rawgit.com/Stewartarmbrecht/xBDD/master/xBDD/test/xBDD.Reporting.Test/xBDD.Reporting.Test.TestResults.html) - Generating reports from a test run.
3. [xBDD.Reporting.Database.Test](https://rawgit.com/Stewartarmbrecht/xBDD/master/xBDD/test/xBDD.Reporting.Database.Test/xBDD.Reporting.Database.Test.TestResults.html) - Writing test results to a database.
4. [xBDD.Test](https://rawgit.com/Stewartarmbrecht/xBDD/master/xBDD/test/xBDD.Test/xBDD.Test.TestResults.html) - Features of the project (environment setup and what not).
