using ATLabProject.PageObjects.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using static ATLabProject.Helpers.BrowserHelper;
using static ATLabProject.Helpers.WaitHelper;

namespace ATLabProject.Steps
{
    /// <summary>
    /// Class contains 
    /// steps of login page tests 
    /// and steps of login page tests with different login names
    /// </summary>

    [Binding]
    public sealed class LoginTestsSteps
    {
        public LoginPage LoginPage = new LoginPage();

        [Then(@"Login page is opened")]
        public void LoginPageIsOpened()
        {
            Assert.IsTrue(LoginPage.IsOpened(), "Page is not opened");
        }

        [When(@"I type correct '([^']*)' and password")]
        public void WhenITypeCorrectAndPassword(string p0)
        {
            LoginPage.Login(p0, "secret_sauce");
        }

        HomePage HomePage = new();
        [Then(@"Homepage is opened")]

        public void ThenHomePageIsOpened()
        {
            Assert.IsTrue(HomePage.IsOpened(), "Page is not opened");
        }

        [When(@"I type locked_out_user username in username field and correct password")]
        public void WhenITypeLocked_Out_UserUsernameInUsernameFieldAndCorrectPassword()
        {
            LoginPage.Login("locked_out_user", "secret_sauce");
        }

        [Then(@"'([^']*)' label should appeared\.")]
        public void ThenLabelShouldAppeared_(string p0)
        {
            Assert.IsTrue(LoginPage.ErrorMessage(p0), "Error Message is not showned");
        }

        [When(@"I type the url ""([^""]*)"" at the browser")]
        public void WhenITypeTheUrlAtTheBrowser(string p0)
        {
            SwitchToNextTab();
            GoToUrl(p0);
            WaitUntilVisible(By.Id("user-name"));
        }

        [Then(@"the Login page is opened")]
        public void ThenTheLoginPageIsOpened()
        {
            Assert.IsTrue(LoginPage.IsOpened(), "Page is not opened"); ;
        }

    }
}
