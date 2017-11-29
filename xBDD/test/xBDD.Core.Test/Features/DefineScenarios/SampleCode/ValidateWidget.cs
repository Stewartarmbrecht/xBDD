using System;
using xBDD;
using xBDD.Model;

//Area
namespace MyApp.API.Test.Features.Calendar
{
	//Feature
	[InOrderTo("to ensure widgets properties conform to all business rules")]
	[AsA("developer")]
	[IWouldLikeTo("have a utility that will validate the widget")]
	public class ValidateWidget
	{
		//Scenario
		public async void WithInvalidName()
		{
			Wrapper<WidgetValidator> validator = new Wrapper<WidgetValidator>();
			Wrapper<Widget> widget = new Wrapper<Widget>();
			Wrapper<Exception> exception = new Wrapper<Exception>();
			await xB.CurrentRun
				.AddScenario(this)
				.Given(WidgetValidatorUser.CreatesAWidgetValidator(validator))
				.And("the user has a widget with an invalid name", (s) => {
					widget.Object = new Widget()
					{
						Name = 	"1 starts with number"
					};
				})
				.When(WidgetValidatorUser.ValidatesTheWidget(widget, validator, exception))
				.Then("the validator should throw an exception with the message 'Widget names can not start with a number.'", (s) => {
					if(exception.Object.Message != "Widget names can not start with a number.")
					{
						throw new Exception($"The exception did not have a message of 'Widget names can not start with a number.' it was '{exception.Object.Message}'");
					}
				})
				.Run();
		}
	}
    public static class WidgetValidatorUser
    {
        internal static Step CreatesAWidgetValidator(Wrapper<WidgetValidator> validator)
        {
            return xB.CreateStep("the user creates an instance of a widget validator", (s) => {
				validator.Object = new WidgetValidator();
			});
        }

        internal static Step ValidatesTheWidget(Wrapper<Widget> widget, Wrapper<WidgetValidator> validator, Wrapper<Exception> exception)
        {
            return xB.CreateStep("the user validates the widget", (s) => {
				try 
				{
					validator.Object.ValidateWidget(widget.Object);
				}
				catch(Exception ex)
				{
					exception.Object = ex;
				}
			});
        }
    }

	public class WidgetValidator
	{
		public void ValidateWidget(Widget widget)
		{
			//Code here
		}
	}
	
	public class Widget
	{
		public string Name { get; set; }
	}
}