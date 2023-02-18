using OpenQA.Selenium;
using static ATLabProject.Helpers.BrowserHelper;
using static ATLabProject.Helpers.WaitHelper;
using static ATLabProject.Helpers.Logger;

namespace ATLabProject.PageObjects.Controls
{
    /// <summary>
    /// Abstract class of page controller
    /// /// </summary>
    public abstract class BaseControl : IWebControl
    {
        public string Name { get; }
        public By Locator;

        protected BaseControl(string name, By locator)
        {
            Name = name;
            Locator = locator;
        }

        public IWebElement Find()
        {
            try
            {
                return Driver.FindElement(Locator);
            }
            catch (NoSuchElementException e)
            {
                throw new Exception($"{this} not found on page.", e);
            }
        }

        public IWebControl Click()
        {
            Find().Click();

            return this;
        }

        public void WaitForVisible(int? timeout = null)
        {
            Log.Info($"Waiting {this} for visible state within {timeout} seconds.");
            try
            {
                WaitUntilVisible(Locator, timeout: timeout);
            }
            catch (Exception e)
            {
                throw new ElementNotVisibleException($"{this} not visible on page in {timeout} seconds.", e);
            }
        }

        public bool IsVisible(int timeout = 5)
        {
            return IsElementVisible(Locator, timeout);
        }

        public virtual string GetText()
        {
            WaitForVisible();
            return Find().GetAttribute("innerText");
        }
    }
}
