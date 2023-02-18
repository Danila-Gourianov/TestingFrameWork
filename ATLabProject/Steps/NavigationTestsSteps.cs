using ATLabProject.PageObjects.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;
using static ATLabProject.Helpers.BrowserHelper;

namespace ATLabProject.Steps
{
    /// <summary>
    /// Class contains steps of navigation tests 
    /// </summary>
    [Binding]
    public class NavigationTests
    {
        private const string TwitterUrl = "https://twitter.com/saucelabs";
        private const string FacebookUrl = "facebook.com/saucelabs";
        private const string LinkedinUrl = "https://www.linkedin.com/company/sauce-labs/";
        private const string HomePageUrl = "https://www.saucedemo.com/inventory.html";
        private const string OverviewPageUrl = "https://www.saucedemo.com/checkout-step-two.html";
        private const string CheckoutPageUrl = "https://www.saucedemo.com/checkout-step-one.html";
        private const string CartPageUrl = "https://www.saucedemo.com/cart.html";

        public HomePage HomePage = new HomePage();
        public LoginPage LoginPage = new LoginPage();
        public ProductPage ProductPage = new ProductPage();
        public OverviewPage OverviewPage = new OverviewPage();
        public CheckoutPage CheckoutPage = new();
        public CartPage CartPage = new();

        [Given(@"Open Home page")]
        public void OpenHomePage()
        {
            GoToUrl(HomePageUrl);
        }

        [When(@"Click Twitter link")]
        public void FollowTwitterLink()
        {
            HomePage.TwitterLink.FollowLink();
            SwitchToNextTab();
        }

        [Then(@"Twitter saucelabs page is opened")]
        public void TwitterSauceLabsPageIsOpened()
        {
            Assert.IsTrue(GetUrl().Contains(TwitterUrl));
        }

        [Given(@"User logged in with (.*) as username and (.*) as password")]
        public void Login(string username, string password)
        {
            LoginPage.Login(username, password);
        }

        [When(@"Click Facebook link")]
        public void FollowFacebookLink()
        {
            HomePage.FacebookLink.FollowLink();
            SwitchToNextTab();
        }

        [Then(@"Facebook saucelabs page is opened")]
        public void FacebookSauceLabsPageIsOpened()
        {
            Assert.IsTrue(GetUrl().Contains(FacebookUrl));
        }

        [When(@"Click Linkedin link")]
        public void FollowLinkedinLink()
        {
            HomePage.LinkedinLink.FollowLink();
            SwitchToNextTab();
        }

        [Then(@"Linkedin saucelabs page is opened")]
        public void LinkedinSauceLabsPageIsOpened()
        {
            Assert.IsTrue(GetUrl().Contains(LinkedinUrl));
        }

        [Given(@"Open Product page")]
        public void OpenProductPage()
        {
            HomePage.BackPackLink.Click();
        }

        [When(@"Click back to products button")]
        public void ClickBackToProductsButton()
        {
            ProductPage.BackToProductsButton.Click();
        }

        [Then(@"Home page is opened")]
        public void HomePageIsOpened()
        {
            Assert.IsTrue(HomePage.IsOpened());
        }

        [Given(@"Open Overview page")]
        public void OpenOverviewPage()
        {
            GoToUrl(OverviewPageUrl);
        }

        [When(@"Click cancel button on the overview page")]
        public void ClickCancelButtonOnTheOverviewPage()
        {
            OverviewPage.CancelButton.Click();
        }

        [Given(@"Open checkout page")]
        public void GivenOpenCheckoutPage()
        {
            GoToUrl(CheckoutPageUrl);
        }

        [When(@"Click cancel button on the checkout page")]
        public void WhenClickCancelButtonOnTheCheckoutPage()
        {
            CheckoutPage.CancelButton.Click();
        }

        [Then(@"cart page is opened")]
        public void ThenCartPageIsOpened()
        {
            Assert.IsTrue(CartPage.IsOpened());
        }
    }
}