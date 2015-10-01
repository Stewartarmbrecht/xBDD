using Xunit;
using xBDD.Model;

namespace xBDD.Core.Test.Features.RunTests.SampleCode
{
    public class WebPage
    {
        public string Title { get; set; }
        public WebPage Click(string buttonName) { return new WebPage() { Title = "Registration" }; }
        public static WebPage NavigateTo(string url) { return new WebPage(); }
    }

    public class AddAReusableStepThatUsesObjectCreatedInPreviousStep
    {
        public Scenario Add(Wrapper<int> count)
        {
            Wrapper<WebPage> sut = new Wrapper<WebPage>();
            var scenario = xBDD.CurrentRun
                .AddScenario(this)
                .Given(WebUser.NavigatesToPage("http://www.myUrl.com", sut, count))
                .When(WebUser.ClicksTheButton("Register", sut, count))
                .Then(WebPageTarget.WillHaveATitleOf("Registration", sut, count));

            scenario.Run();

            return scenario.Scenario;
        }
    }

    public static class WebUser
    {
        internal static Step NavigatesToPage(string url, Wrapper<WebPage> widget, Wrapper<int> count)
        {
            return xBDD.CreateStep("the user navigates to page",
                (s) =>
                {
                    widget.Object = WebPage.NavigateTo(url);
                    count.Object++;
                });
        }

        internal static Step ClicksTheButton(string name, Wrapper<WebPage> sut, Wrapper<int> count)
        {
            return xBDD.CreateStep("the user clicks the '" + name + "' button",
                (s) =>
                {
                    sut.Object = sut.Object.Click(name);
                    count.Object++;
                });
        }
    }
    public class WebPageTarget
    {
        internal static Step WillHaveATitleOf(string expectedName, Wrapper<WebPage> sut, Wrapper<int> count)
        {
            return xBDD.CreateStep("the web page will have a title of '" + expectedName + "'",
                (s) =>
                {
                    Assert.Equal(expectedName, sut.Object.Title);
                    count.Object++;
                });
        }
    }
}
