//using Xunit;

//namespace xBDD.Test.Sample
//{
//    public class LogIn
//    {
//        [Fact]
//        public void ValidCredentials()
//        {
//            var s = new Steps();
//            s.UserName = "mytest@test.com";
//            s.Password = "mypassword";
//            s.ExpectedMessage = "Welcome to the site!";
//            s.PageTitle = "Home";
//            xBDD.CurrentRun.AddScenario(this)
//                .When(s.the_user_logs_in_with_UserName_and_Password)
//                .Then(s.the_user_should_see_a_message_of_ExpectedMessage)
//                .And(s.the_page_title_should_be_PageTitle)
//                .Run();
//        }

//        [Fact]
//        public void InvalidCredentials()
//        {
//            var s = new Steps();
//            s.UserName = "mytest@test.com";
//            s.Password = "wrongpassword";
//            s.ExpectedMessage = "A user with password does not exist!";
//            s.PageTitle = "Log In";
//            xBDD.CurrentRun.AddScenario(this)
//                .When(s.the_user_logs_in_with_UserName_and_Password)
//                .Then(s.the_user_should_see_a_message_of_ExpectedMessage)
//                .And(s.the_page_title_should_be_PageTitle)
//                .Run();
//        }
//    }

//    public class Steps
//    {
//        public string UserName { get; set; }
//        public string Password { get; set; }
//        public string ExpectedMessage { get; set; }
//        public string PageTitle { get; internal set; }

//        IBaseWebPage landingPage;
//        internal void the_user_logs_in_with_UserName_and_Password(Step step)
//        {
//            step.SetNameWithReplacement("UserName", UserName.Quote(), "Password", Password.Quote());
//            var logInPage = LogInPage.NavigateTo();
//            loginPage.UserName = UserName;
//            logInPage.Password = Password;
//            landingPage = logInPage.Submit();
//        }

//        internal void the_user_should_see_a_message_of_ExpectedMessage(Step obj)
//        {
//            obj.SetNameWithReplacement("ExpectedMessage", ExpectedMessage);
//            Assert.Equal(ExpectedMessage, landingPage.MainMessage);
//        }

//        internal void the_page_title_should_be_PageTitle(Step obj)
//        {
//            obj.SetNameWithReplacement("PageTitle", PageTitle);
//            Assert.Equal(PageTitle, landingPage.Title);
//        }
//    }
//}

///*
//If all passing:

//Test Run - 2015-09-03 12:38:15
//Outcome: 1 Area Passed

//    xBDD.Test.Sample - 1 Feature Passed
//        Log In - 2 Scenarios Passed
//            Valid Credentials - 3 Steps Passed
//                Given the user logs in with 'mytest@test.com' and 'mypassword'
//                Then the user should see a message of 'Welcome to the site!'
//                And the page title should be 'Home'
            
//            Invalid Credentials - 3 Steps Passed
//                Given the user logs in with 'mytest@test.com' and 'wrongpassword'
//                Then the user should see a message of 'A user with password does not exist!'
//                And the page title should be 'Log In'

//If one fails:
    
//Test Run - 2015-09-03 12:38:15
//Outcome: 1 Area Failed

//    xBDD.Test.Sample - 1 Feature Failed
//        Log In - 1 Scenarios Failed of 2
//            Valid Credentials - 3 Steps Passed
//                Given the user logs in with 'mytest@test.com' and 'mypassword'
//                Then the user should see a message of 'Welcome to the site!'
//                And the page title should be 'Home'
            
//            Invalid Credentials - 1 Step Failed & 1 Skipped of 3
//                Given the user logs in with 'mytest@test.com' and 'wrongpassword'
//                Then the user should see a message of 'A user with password does not exist!' (Failed)
//                    Expected: A user with password does not exist!
//                    Actual: The user and password were not valid.
//                And the page title should be 'Log In' (Skipped)

//*/
