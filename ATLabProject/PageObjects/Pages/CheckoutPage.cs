using ATLabProject.PageObjects.Controls;
using OpenQA.Selenium;

namespace ATLabProject.PageObjects.Pages
{
    /// <summary>
    /// Class contains elements and methods of 'Overview' page
    /// </summary>
    public class CheckoutPage : BasePage
    {
        public Button CancelButton => new Button("Cancel button on thecheckout page", By.Id("cancel"));
    }
}