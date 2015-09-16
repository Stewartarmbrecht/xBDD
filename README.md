# xBDD
A Behavior Driven Development framework that runs on xUnit (or any other testing framework - hopefully).

Actually, this might be better defined as Behavior Documented Development.  
xBDD does not strive to create an environment where developers build tests to pass
gherkin statements written by someone else.  Rather, its expected that the developer
will determine and write the scenarios.

We believe that scenarios (written in gherkin) are design artifacts and 
should not be used as requirements.  That should be left to acceptance criteria.

In the ideal environment Product Owners focus on defining stories/features and acceptance criteria.
We see stories and features as the same thing, but we beleive acceptance criteria 
and scenarios are not.  We believe acceptance criteria should be design agnostic and should 
only further explain the user need in the story/feature.  Scenarios on the other
hand are very design aware and speak to how the system behaves in very specific circumstances.

## Goals

1. **Gherkin Style Output** - Reports can be generated from a test run that can be shared 
with a product owner or stakeholder to explain how the system has been designed to meet the user need.
2. **Database Accessible** - Ability to publish test passes to a database to allow for enhanced reporting
and serve as a basis for showing product growth/progress over time.
3. **Step Resuse** - The framework should encourage the development of step libraries that simplify
the process of building future tests.
4. **Intellisense Discovery** - A developer should be able to easily find existing steps using intellisense.
5. **Universal .Net Test Platform Integration** - While named similar to xUnit this framework should be usable
in any testing platform that supports .Net code.  (Right now it's only DNX supported)
6. **DNX Capable** - Capable of running where ever the cross platform .Net framework can.
4. **Hybrid Asynchronous Support** - You can define scenarios that run both synchronous and asynchronous steps.

## Example 

using Xunit;

    namespace xBDD.Test.Sample
    {
        public class LogIn
        {
            [Fact]
            public void ValidCredentials()
            {
                var s = new Steps();
                s.UserName = "mytest@test.com";
                s.Password = "mypassword";
                s.ExpectedMessage = "Welcome to the site!";
                s.PageTitle = "Home";
                xBDD.CurrentRun.AddScenario(this)
                    .When(s.the_user_logs_in_with_UserName_and_Password)
                    .Then(s.the_user_should_see_a_message_of_ExpectedMessage)
                    .And(s.the_page_title_should_be_PageTitle)
                    .Run();
            }

            [Fact]
            public void InvalidCredentials()
            {
                var s = new Steps();
                s.UserName = "mytest@test.com";
                s.Password = "wrongpassword";
                s.ExpectedMessage = "A user with password does not exist!";
                s.PageTitle = "Log In";
                xBDD.CurrentRun.AddScenario(this)
                    .When(s.the_user_logs_in_with_UserName_and_Password)
                    .Then(s.the_user_should_see_a_message_of_ExpectedMessage)
                    .And(s.the_page_title_should_be_PageTitle)
                    .Run();
            }
        }

        public class Steps
        {
            public string UserName { get; set; }
            public string Password { get; set; }
            public string ExpectedMessage { get; set; }
            public string PageTitle { get; internal set; }

            IBaseWebPage landingPage;
            internal void the_user_logs_in_with_UserName_and_Password(Step step)
            {
                step.SetNameWithReplacement("UserName", UserName.Quote(), "Password", Password.Quote());
                var logInPage = LogInPage.NavigateTo();
                loginPage.UserName = UserName;
                logInPage.Password = Password;
                landingPage = logInPage.Submit();
            }

            internal void the_user_should_see_a_message_of_ExpectedMessage(Step obj)
            {
                obj.SetNameWithReplacement("ExpectedMessage", ExpectedMessage);
                Assert.Equal(ExpectedMessage, landingPage.MainMessage);
            }

            internal void the_page_title_should_be_PageTitle(Step obj)
            {
                obj.SetNameWithReplacement("PageTitle", PageTitle);
                Assert.Equal(PageTitle, landingPage.Title);
            }
        }
    }

    /*
    If all passing:

    Test Run - 2015-09-03 12:38:15
    Outcome: 1 Area Passed

        xBDD.Test.Sample - 1 Feature Passed
            Log In - 2 Scenarios Passed
                Valid Credentials - 3 Steps Passed
                    Given the user logs in with 'mytest@test.com' and 'mypassword'
                    Then the user should see a message of 'Welcome to the site!'
                    And the page title should be 'Home'
            
                Invalid Credentials - 3 Steps Passed
                    Given the user logs in with 'mytest@test.com' and 'wrongpassword'
                    Then the user should see a message of 'A user with password does not exist!'
                    And the page title should be 'Log In'

    If one fails:
    
    Test Run - 2015-09-03 12:38:15
    Outcome: 1 Area Failed

        xBDD.Test.Sample - 1 Feature Failed
            Log In - 1 Scenarios Failed of 2
                Valid Credentials - 3 Steps Passed
                    Given the user logs in with 'mytest@test.com' and 'mypassword'
                    Then the user should see a message of 'Welcome to the site!'
                    And the page title should be 'Home'
            
                Invalid Credentials - 1 Step Failed & 1 Skipped of 3
                    Given the user logs in with 'mytest@test.com' and 'wrongpassword'
                    Then the user should see a message of 'A user with password does not exist!' (Failed)
                        Expected: A user with password does not exist!
                        Actual: The user and password were not valid.
                    And the page title should be 'Log In' (Skipped)

    */


