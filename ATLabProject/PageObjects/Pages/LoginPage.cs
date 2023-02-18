using ATLabProject.PageObjects.Controls;
using OpenQA.Selenium;

namespace ATLabProject.PageObjects.Pages
{
    /// <summary>
    /// Class contains elements and methods of 'Login' page
    /// </summary>
    public class LoginPage : BasePage
    {
        public TextBox UserNameTextBox => new("User name input", By.Id("user-name"));
        public TextBox PasswordInput => new("Password input", By.Id("password"));
        public Button LoginButton => new("Login button", By.Id("login-button"));


        public bool IsOpened() => UserNameTextBox.IsVisible() && PasswordInput.IsVisible() && LoginButton.IsVisible();

        public void Login(string login, string password)
        {
            EnterLogin(login);
            EnterPassword(password);
            LoginButton.Click();
        }

        public void EnterLogin(string login) => UserNameTextBox.EnterText(login);
        public void EnterPassword(string password) => PasswordInput.EnterText(password);

        internal bool? ErrorMessage(string p0)
        {
            TextBox ErrorMessageTextBox = new("Error Message", By.XPath("//*[contains(text(),'Epic sadface: Sorry, this user has been locked out.')]"));
            return ErrorMessageTextBox.IsVisible();
        }
    }
}