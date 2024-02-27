using AimyOneLoginTest.Components.LoginPageComponent;
using AimyOneLoginTest.Drivers;
using AimyOneLoginTest.TestData.LoginCredential;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace AimyOneLoginTest.FeatureStepDefinitions
{
    [Binding]
    public class LoginFeatureStepDefinitions : Hook
    {
        private Login login;

        public LoginFeatureStepDefinitions()
        {
            login = new Login();
        }

        [Given(@"I use this valid credentials json file to login the protal")]
        public void GivenIUseThisValidCredentialsJsonFileToLoginTheProtal()
        {
            var jsonPath = File.ReadAllText(@"G:\AimyOneProject\EddieAimyOne\EddieAimyOneProject\EddieAimyOneProject\EddieAimyOneProject\TestData\LoginCredential\DataFiles\UserData.json");
            var userData = JsonConvert.DeserializeObject<UserData>(jsonPath);

            ScenarioContext.Current.Set(userData, "UserData");
        }

        [Then(@"I enter valid username and valid password")]
        public void ThenIEnterValidUsernameAndValidPassword()
        {
            var jsonData = ScenarioContext.Current.Get<UserData>("UserData");

            string loginUsername = jsonData.username;
            string loginPassword = jsonData.password;

            login.loginWithCredentails(loginUsername, loginPassword);
        }

        [Then(@"I should be able to see my account username showing on the profile page")]
        public void ThenIShouldBeAbleToSeeMyAccountUsernameShowingOnTheProfilePage()
        {
            string expecedAccountName = login.assertUsername();
            Assert.That(expecedAccountName == "Eddie He", "Actual account name and expected account name do not match!");
        }

        [Given(@"I enter empty '([^']*)' and valid '([^']*)'")]
        public void GivenIEnterEmptyAndValid(string username, string password)
        {
            login.loginWithCredentails(username, password);
        }

        [Then(@"I should be able to see the error username message popup")]
        public void ThenIShouldBeAbleToSeeTheErrorUsernameMessagePopup()
        {
            string expecedErrorMessage = login.invalidCredentialsMessage();
            Assert.That(expecedErrorMessage == "The Username field is required.", "Actual error message and expected error message do not match!");
        }

        [Given(@"I enter valid '([^']*)' and empty '([^']*)'")]
        public void GivenIEnterValidAndEmpty(string username, string password)
        {
            login.loginWithCredentails(username, password);
        }


        [Then(@"I should be able to see the password error message popup")]
        public void ThenIShouldBeAbleToSeeThePasswordErrorMessagePopup()
        {
            string expecedErrorMessage = login.invalidCredentialsMessage();
            Assert.That(expecedErrorMessage == "The Password field is required.", "Actual error message and expected error message do not match!");
        }

        [Given(@"I enter the '([^']*)' and '([^']*)'")]
        public void GivenIEnterTheAnd(string username, string password)
        {
            login.loginWithCredentails(username, password);
        }

        [Then(@"I should be able to see the invaild credentials error message")]
        public void ThenIShouldBeAbleToSeeTheInvaildCredentialsErrorMessage()
        {
            string expecedErrorMessage = login.invalidCredentialsMessage();
            Assert.That(expecedErrorMessage == "Invalid username or password", "Actual error message and expected error message do not match!");
        }
    }
}
