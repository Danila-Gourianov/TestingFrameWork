using ATLabProject.PageObjects.Controls;
using OpenQA.Selenium;

namespace ATLabProject.PageObjects.Pages
{
    /// <summary>
    /// Class contains elements and methods of 'Home' page
    /// </summary>
    public class HomePage : BasePage
    {
        public Link TwitterLink => new Link("Link to Twitter", By.XPath("//a[contains(@href, 'twitter.com/saucelabs')]"));
        public Link FacebookLink => new Link("Link to Facebook", By.XPath("//a[contains(@href, 'facebook.com/saucelabs')]"));
        public Link LinkedinLink => new Link("Link to Linkedin", By.XPath("//a[contains(@href, 'linkedin.com/company/sauce-labs')]"));
        public Link BackPackLink => new Link("Back pack link", By.Id("item_4_title_link"));
        public bool IsOpened() => BackPackLink.IsVisible() && TwitterLink.IsVisible();
    }
}
