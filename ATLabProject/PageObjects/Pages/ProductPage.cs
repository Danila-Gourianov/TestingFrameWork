using ATLabProject.PageObjects.Controls;
using OpenQA.Selenium;

namespace ATLabProject.PageObjects.Pages
{
    /// <summary>
    /// Class contains elements and methods of 'Product' page
    /// </summary>
    public class ProductPage : BasePage
    {
        public Button BackToProductsButton => new Button("Back to products button", By.Id("back-to-products"));
    }
}