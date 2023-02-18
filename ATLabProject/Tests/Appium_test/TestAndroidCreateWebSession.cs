using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using System;
//using AppiumDotNetSamples.Helper;
using ATLabProject.Helpers;

namespace ATLabProject.Tests.Appium_test
{
    [TestFixture()]
    public class AndroidCreateWebSessionTest
    {

        private IWebDriver driver;

        [OneTimeSetUp()]
        public void BeforeAll()
        {
            AppiumOptions capabilities = new AppiumOptions();
            capabilities.AddAdditionalCapability(MobileCapabilityType.BrowserName, "Chrome");
            capabilities.AddAdditionalCapability(MobileCapabilityType.PlatformName, App.AndroidDeviceName());
            capabilities.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, App.AndroidPlatformVersion());
            capabilities.AddAdditionalCapability(MobileCapabilityType.AutomationName, "UIAutomator2");
            capabilities.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Pixel 2 API 33");

            //driver = new AndroidDriver<AppiumWebElement>(Env.ServerUri(), capabilities, Env.INIT_TIMEOUT_SEC);
            //driver.Manage().Timeouts().ImplicitWait = Env.IMPLICIT_TIMEOUT_SEC;
        }

        [Test()]
        public void TestShouldCreateAndDestroyAndroidwebSessions()
        {
            driver.Url = "https://www.google.com";
            String title = driver.Title;

            Assert.AreEqual("Google", title);

            driver.Quit();

            Assert.Throws<WebDriverException>(
                () => { title = driver.Title; });
        }
    }
}