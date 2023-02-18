using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
//using AppiumDotNetSamples.Helper;
using ATLabProject.Helpers;

namespace ATLabProject.Tests.Appium_test
{
    [TestFixture()]
    public class AndroidSelectorsTest
    {
        private AndroidDriver<AndroidElement> driver;

        [OneTimeSetUp()]
        public void BeforeAll()
        {
            AppiumOptions capabilities = new AppiumOptions();
            capabilities.AddAdditionalCapability(MobileCapabilityType.BrowserName, "");
            capabilities.AddAdditionalCapability(MobileCapabilityType.PlatformName, App.AndroidDeviceName());
            capabilities.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, App.AndroidPlatformVersion());
            capabilities.AddAdditionalCapability(MobileCapabilityType.AutomationName, "UIAutomator2");
            capabilities.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Pixel 2 API 33");

            capabilities.AddAdditionalCapability(MobileCapabilityType.App, App.AndroidApp());

            driver = new AndroidDriver<AndroidElement>(Env.ServerUri(), capabilities, Env.INIT_TIMEOUT_SEC);
            driver.Manage().Timeouts().ImplicitWait = Env.IMPLICIT_TIMEOUT_SEC;
        }

        [OneTimeTearDown()]
        public void AfterAll()
        {
            driver.Quit();
        }

        [Test()]
        public void TestShouldFindElementsByAccessibilityId()
        {
            ICollection<AndroidElement> elements = driver.FindElementsByAccessibilityId("Content");
            Assert.AreEqual(1, elements.Count);
        }

        [Test()]
        public void TestShouldFindElementsById()
        {
            ICollection<AndroidElement> elements = driver.FindElementsById("android:id/action_bar_container");
            Assert.AreEqual(1, elements.Count);
        }

        [Test()]
        public void TestShouldFindElementsByClassName()
        {
            ICollection<AndroidElement> elements = driver.FindElementsByClassName("android.widget.FrameLayout");
            Assert.AreEqual(3, elements.Count);
        }

        [Test()]
        public void TestShouldFindElementsByXPath()
        {
            ICollection<AndroidElement> elements = driver.FindElementsByXPath("//*[@class='android.widget.FrameLayout']");
            Assert.AreEqual(3, elements.Count);
        }
    }
}