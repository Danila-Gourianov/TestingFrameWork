using OpenQA.Selenium;

namespace ATLabProject.PageObjects.Controls
{
    /// <summary>
    /// Class for methods and elements of TextBox control
    /// </summary>
    public class TextBox : BaseControl
    {
        public TextBox(string name, By locator) : base(name, locator)
        {

        }

        public void EnterText(string text)
        {
            WaitForVisible();
            if (GetText() != text)
            {
                Find().SendKeys(text);
            }
        }

        public override string GetText()
        {
            WaitForVisible();
            return Find().GetAttribute("value");
        }
    }
}
