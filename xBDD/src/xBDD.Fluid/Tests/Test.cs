using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xBDD.Fluid.Tests.Steps;

namespace xBDD.Fluid
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class Test
    {
        public void UserViewsAboutPage()
        {
            xBDD.TestRun
                .AddScenario("User Views About Page")
                .Given(User.LogsIn("MyUser", "MyPassword"))
                .When(User.Clicks("About"))
                .Then(User.ShouldSeeATitleOf("About"))
                .Run();
        }
        public void UserLogsIn()
        {
            xBDD.TestRun
                .AddScenario("User Logs In")
                .Given(User.Exists("MyUser", "MyPassword"))
                .When(User.NavigatesTo("Home"))
                .And(User.UpdatesField("userName", "MyUser"))
                .And(User.UpdatesField("password", "MyPassword"))
                .When(User.Clicks("Submit"))
                .Then(User.ShouldSeeATitleOf("Home"))
                .And(User.ShouldSeeMessageOf("Welcome MyUser!"))
                .Run();
        }
        public void WebUserLogsIn()
        {
            LogInPage sut = null;
            xBDD.TestRun
                .AddNewScenario("User Logs In")
                .Given(WebUser.Exists("MyUser", "MyPassword"))
                .When(WebUser.NavigatesTo(sut))
                .And(WebUser.UpdatesField("userName", "MyUser", sut))
                .And(WebUser.UpdatesField("password", "MyPassword", sut))
                .When(WebUser.Clicks("Submit", sut))
                .Then(WebUser.ShouldSeeATitleOf("Home", sut))
                .And(WebUser.ShouldSeeMessageOf("Welcome MyUser!", sut))
                .Run();
        }
        public void UserRegisters()
        {
            xBDD.TestRun
                .AddScenario("User Registers")
                .Given(User.FirstNavigatesTo("Registration"))
                .And(User.UpdatesField("user-name", "JohnDoe"))
                .And(User.UpdatesField("password", "password1"))
                .And(User.UpdatesField("first-name", "John"))
                .And(User.UpdatesField("last-name", "Doe"))
                .And(User.UpdatesField("email-adress", "john@doe.com"))
                .When(User.Clicks("Submit"))
                .Then(User.ShouldSeeATitleOf("Home"))
                .And(User.ShouldSeeMessageOf("Welcome John Doe!"))
                .Run();
        }
        public void AddTwoNumbers()
        {
            xBDD.TestRun
                .AddScenario("Add Two Numbers")
                .Given(CalculatorUser.GetsACalculator())
                .When(CalculatorUser.Presses("2"))
                .And(CalculatorUser.Presses("+"))
                .And(CalculatorUser.Presses("2"))
                .And(CalculatorUser.Presses("="))
                .Then(CalculatorUser.ShouldSeeAResultOf(4))
                .Run();
        }
        public void SubtractTwoNumbers()
        {
            xBDD.TestRun
                .AddScenario("Subtract Two Numbers")
                .Given(CalculatorUser.GetsACalculator())
                .When(CalculatorUser.Presses("2"))
                .And(CalculatorUser.Presses("-"))
                .And(CalculatorUser.Presses("2"))
                .And(CalculatorUser.Presses("="))
                .Then(CalculatorUser.ShouldSeeAResultOf(0))
                .Run();
        }
        public void SubtractTwoNumbersManual()
        {
            Calculator sut = null;
            xBDD.TestRun
                .AddScenario("Subtract Two Numbers")
                .Given("a calculator", () => {
                    sut = new Calculator();
                })
                .When("the user enters '2 + 2 ='", () => {
                    sut.Enter("2");
                    sut.Enter("+");
                    sut.Enter("2");
                    sut.Enter("=");
                })
                .Then("the display should be 4", () => {
                    if (sut.Display != 4)
                        throw new Exception("Display was not 4 it was '" + sut.Display + "'");
                })
                .Run();
        }

        public void MultiplyTwoNumbers()
        {
            Calculator sut = null;
            xBDD.TestRun
                .AddScenario("Multilpy Two Numbers")
                .Given(CalculatorUser.HasACalculator(sut))
                .When(CalculatorUser.EntersASeries(sut, "2", "*", "2", "="))
                .Then(CalculatorUser.ShouldSeeADisplayOf(sut, "4"))
                .Run();
        }
    }
}
