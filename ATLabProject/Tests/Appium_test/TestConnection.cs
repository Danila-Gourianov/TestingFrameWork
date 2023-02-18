using NUnit.Framework;

using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;

using System;
using System.Collections.Generic;

namespace ATLabProject.Tests.Appium_test
{

    [TestFixture()]

    public class AndroidTestConnection
    {
        AndroidDriver<AndroidElement> driver;


        [SetUp]
        public void InitDriver()
        {
            AppiumOptions capabilities = new AppiumOptions();
            capabilities.AddAdditionalCapability("platformName", "Android");
            capabilities.AddAdditionalCapability("deviceName", "Pixel 2 API 33");
            capabilities.AddAdditionalCapability("appPackage", "com.android.dialer");
            capabilities.AddAdditionalCapability("appActivity", "DialtactsActivity");
            driver = new AndroidDriver<AndroidElement>(capabilities);
            driver.Navigate().GoToUrl("http://127.0.01:4723/wd/hub");
        }

        [Test]
        public void TestConnection()
        {
            Assert.IsNotNull(driver);
            System.Threading.Thread.Sleep(2000);
        }

        [TearDown]
        public void closeDriver()
        {
            driver.Quit();
        }
    }
}