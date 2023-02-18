using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using System;
// AppiumDotNetSamples.Helper;
using ATLabProject.Helpers;

namespace ATLabProject.Tests.Appium_test
{
    [TestFixture()]
    public class AndroidBasicInteractionsTest
    {
        private AndroidDriver<AndroidElement> driver;

        [SetUp()]
        public void BeforeAll()
        {
            AppiumOptions capabilities = new AppiumOptions();
            capabilities.AddAdditionalCapability(MobileCapabilityType.BrowserName, "");
            capabilities.AddAdditionalCapability(MobileCapabilityType.PlatformName, App.AndroidDeviceName());
            capabilities.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, App.AndroidPlatformVersion());
            capabilities.AddAdditionalCapability(MobileCapabilityType.AutomationName, "UIAutomator2");
            capabilities.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Pixel 2 API 33");
            capabilities.AddAdditionalCapability("appActivity", ".app.SearchInvoke");
            capabilities.AddAdditionalCapability(MobileCapabilityType.App, App.AndroidApp());

            driver = new AndroidDriver<AndroidElement>(Env.ServerUri(), capabilities, Env.INIT_TIMEOUT_SEC);
            driver.Manage().Timeouts().ImplicitWait = Env.IMPLICIT_TIMEOUT_SEC;
        }

        [TearDown()]
        public void AfterAll()
        {
            driver.Quit();
        }

        [Test()]
        public void TestShouldSendKetsToSearchBoxThenCheckTheValue()
        {
            AndroidElement searchBoxElement = driver.FindElementById("txt_query_prefill");
            searchBoxElement.SendKeys("Hello World!");

            AndroidElement onSearchRequestButton = driver.FindElementById("btn_start_search");
            onSearchRequestButton.Click();

            AndroidElement seachText = driver.FindElementById("android:id/search_src_text");
            Assert.AreEqual("Hello World!", seachText.Text);
        }

        [Test()]
        public void TestShouldClickAButtonThatOpensAnAlertAndThenDismissesIt()
        {
            driver.StartActivity("io.appium.android.apis", ".app.AlertDialogSamples");

            AndroidElement openDialogButton = driver.FindElementById("io.appium.android.apis:id/two_buttons");
            openDialogButton.Click();

            AndroidElement alertElement = driver.FindElementById("android:id/alertTitle");
            String alertText = alertElement.Text;
            Assert.AreEqual("Lorem ipsum dolor sit aie consectetur adipiscing\nPlloaso mako nuto siwuf cakso dodtos anr koop.", alertText);

            driver.FindElementById("android:id/button1").Click();
        }
    }
}