using ATLabProject.PageObjects.Controls;
using OpenQA.Selenium;

namespace ATLabProject.PageObjects.Pages
{
    /// <summary>
    /// Class contains elements and methods of 'Overview' page
    /// </summary>
    public class OverviewPage : BasePage
    {
        public Button CancelButton => new Button("Cancel button on the overview page", By.Id("cancel"));
    }
}