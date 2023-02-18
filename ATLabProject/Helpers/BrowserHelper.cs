using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using static ATLabProject.Helpers.Logger;

namespace ATLabProject.Helpers
{
    /// <summary>
    /// Class to initialize webdriver and open/configure/close browser.
    /// </summary>
    public static class BrowserHelper
    {
        [ThreadStatic] 
        private static IWebDriver? driver;
        public static IWebDriver Driver
        {
            get => driver;
            private set => driver = value;
        }

        public static void OpenBrowser()
        {
            try
            {
                Driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory, SetChromeOptions());
            }
            catch (Exception)
            {
                Log.Warning("ChromeDriver failed to initialize. Retrying the connection...");
                Thread.Sleep(50000);
                Driver = new ChromeDriver(SetChromeOptions());
            }

            Driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(10));
            Driver.Manage().Window.Maximize();
        }

        /// <summary>
        /// Set Chrome Options
        /// </summary>
        /// <returns>Set of chrome options</returns>
        private static ChromeOptions SetChromeOptions()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--headless");
            chromeOptions.AddArgument("--no-sandbox");
            chromeOptions.AddArgument("--disable-dev-shm-usage");

            return chromeOptions;
        }

        public static void CloseBrowser()
        {
            Log.Info("Close browser instance:");
            Driver.Quit();
            Driver.Dispose();
            Driver = null;
            Log.Info("-> browser instance closed.");
        }
        
        public static void ClearBrowserCookies()
        {
            Driver.Manage().Cookies.DeleteAllCookies();
        }

        public static void GoToUrl(string url)
        {
            Log.Info($"Open {url}");
            Driver.Navigate().GoToUrl(url);
        }

        public static void WaitForPageStateComplete(int timeout = 20)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
            wait.Until(d =>
                ((IJavaScriptExecutor)Driver).ExecuteScript("return document.readyState").Equals("complete"));
        }
        
        public static void SwitchToPreviousTab()
        {
            var currentWindowHandleIndex = Driver.WindowHandles.IndexOf(Driver.CurrentWindowHandle);
            var windowHandles = Driver.WindowHandles;

            if (currentWindowHandleIndex is not 0)
            {
                Driver.SwitchTo().Window(windowHandles[currentWindowHandleIndex - 1]);
            }
        }

        public static void SwitchToNextTab()
        {
            var currentWindowHandleIndex = Driver.WindowHandles.IndexOf(Driver.CurrentWindowHandle);
            var windowHandles = Driver.WindowHandles;
            
            if (currentWindowHandleIndex != windowHandles.Count - 1)
            {
                Driver.SwitchTo().Window(windowHandles[currentWindowHandleIndex + 1]);
            }
        }

        public static string GetUrl() => Driver.Url;
    }
}