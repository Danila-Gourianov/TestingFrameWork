using ATLabProject.PageObjects.Controls;
using OpenQA.Selenium;

namespace ATLabProject.PageObjects.Pages
{
    /// <summary>
    /// Class contains elements and methods of 'Overview' page
    /// </summary>
    public class CartPage : BasePage
    {
        public Button CancelButton => new Button("Continue Shopping button on the cart page", By.Id("continue-shopping"));

        TextBox CartTextBox = new("Your Cart Title", By.XPath("//*[contains(text(),'Your Cart')]"));
        public bool IsOpened() => CartTextBox.IsVisible();
    }
}