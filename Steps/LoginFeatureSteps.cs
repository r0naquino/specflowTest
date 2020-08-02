using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowProject.PageModel;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject.Steps
{
    [Binding]
    public class LoginFeatureSteps
    {

        private IWebDriver driver;
        private BasePage basePage;
        private LoginPage loginPage;
        private HomePage homePage;
        private ScenarioContext scenarioContext;

        public LoginFeatureSteps(ScenarioContext scenarioContext)
        {
            driver = scenarioContext.Get<IWebDriver>("driver");
            basePage = new BasePage(driver);
            this.scenarioContext = scenarioContext;
        }
        
        [Given(@"the user is in the login page")]
        public void GivenTheUserIsIsInTheLoginPage()
        {
            loginPage = basePage.GoToLoginPage();
        }
        
        [When(@"the user has no username and password are inputted")]
        public void WhenNoUsernameAndPasswordAreInputted()
        {
            loginPage.InputUsernameAndPassword("", "");
        }
        
        [Then(@"An error message that ""(.*)"" is displayed")]
        public void ThenAnErrorMessageThatIsDisplayed(string errorMessage)
        {
            Assert.IsTrue(loginPage.VerifyLoginErrorMessage(errorMessage), $"Invalid/Missing error message for Test Case {scenarioContext.ScenarioInfo.Title}");
        }

        [When(@"the user input ""(.*)"" in username field and ""(.*)"" in password field")]
        public void WhenTheUserInputInUsernameFieldAndInPasswordField(string userName, string password)
        {
            homePage = loginPage.InputUsernameAndPassword(userName, password);
        }

        [Then(@"the Home page is displayed")]
        public void ThenTheHomePageIsDisplayed()
        {
            Assert.IsTrue(homePage.VerifyIfHomePageIsLoaded(), $"Home page is not displayed for Test Case {scenarioContext.ScenarioInfo.Title}");
        }

    }
}
