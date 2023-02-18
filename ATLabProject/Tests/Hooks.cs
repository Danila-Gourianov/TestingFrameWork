using Allure.Commons;
using TechTalk.SpecFlow;
using static ATLabProject.Helpers.BrowserHelper;

namespace ATLabProject.Tests
{
    [Binding]
    public sealed class Hooks
    {
        public static AllureLifecycle allure = AllureLifecycle.Instance;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            allure.CleanupResultDirectory();

        }

    [BeforeScenario]
        public static void BeforeScenarioRun()
        {
            OpenBrowser();
            ClearBrowserCookies();
            GoToUrl("https://www.saucedemo.com/");
        }

        [AfterScenario]
        public static void AfterScenarioRun()
        {
            CloseBrowser();
        }
    }
}