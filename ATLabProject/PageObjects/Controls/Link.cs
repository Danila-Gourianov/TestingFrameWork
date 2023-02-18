using OpenQA.Selenium;

namespace ATLabProject.PageObjects.Controls
{
    /// <summary>
    /// Class for methods and elements of Link control
    /// </summary>
    public class Link : BaseControl
    {
        public Link(string name, By locator) : base(name, locator)
        {
        }

        public void FollowLink()
        {
            WaitForVisible();
            Click();
        }
    }
}