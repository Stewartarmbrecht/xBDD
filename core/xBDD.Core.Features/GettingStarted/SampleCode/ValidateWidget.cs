using System;
using xBDD;
using xBDD.Model;

//Area
namespace MyApp.UnitTesting.Accounts
{
	//Feature
	[AsA("developer")]
	[YouCan("ensure a Accounts properties conform to all business rules")]
	[By("using a AccountValidator utility")]
	// [TestClass] - for MSTest
	// [TestFixture] - for nUnit
	public class UsingAccountValidator
	{
		//Scenario
		// [Fact] - for xUnit
		// [Test] - for nUnit
		public async void InvalidAccountName()
		{
			Wrapper<AccountValidator> validator = new Wrapper<AccountValidator>();
			Wrapper<Account> Account = new Wrapper<Account>();
			Wrapper<Exception> exception = new Wrapper<Exception>();
			
			await xB.AddScenario(this)
				.Given(You.CreateAAccountValidator(validator))
				.And(You.CreateAAccountWithTheName("1 stars with a number", Account))
				.When(You.ValidateTheAccount(Account, validator, exception))
				.Then(You.WillReceiveAnExceptionWithTheMessage("Account names can not start with a number.", exception))
				.Run();
		}
	}
    public static class You
    {
        internal static Step CreateAAccountValidator(Wrapper<AccountValidator> validator)
        {
            return xB.CreateStep("the user creates an instance of a Account validator", (s) => {
				validator.Object = new AccountValidator();
			});
        }

        internal static Step CreateAAccountWithTheName(string name, Wrapper<Account> Account)
        {
            return xB.CreateStep("the user creates an instance of a Account validator", (s) => {
				Account.Object = new Account()
				{
					Name = 	name
				};
			});
        }

        internal static Step ValidateTheAccount(Wrapper<Account> Account, Wrapper<AccountValidator> validator, Wrapper<Exception> exception)
        {
            return xB.CreateStep("the user validates the Account", (s) => {
				try 
				{
					validator.Object.ValidateAccount(Account.Object);
				}
				catch(Exception ex)
				{
					exception.Object = ex;
				}
			});
        }
        internal static Step WillReceiveAnExceptionWithTheMessage(string message, Wrapper<Exception> exception)
        {
            return xB.CreateStep("the user validates the Account", (s) => {
				if(exception.Object.Message != message)
				{
					throw new Exception($"The exception did not have a message of '{message}' it was '{exception.Object.Message}'");
				}
			});
        }
    }

	public class AccountValidator
	{
		public void ValidateAccount(Account Account)
		{
			//Code here
		}
	}
	
	public class Account
	{
		public string Name { get; set; }
	}
}