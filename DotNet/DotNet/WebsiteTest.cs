using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using Applitools;
using System.Drawing;
using OpenQA.Selenium;

namespace DotNet
{
    [TestClass]
    public class WebsiteTest
    {
        private IWebDriver driver;
        private Eyes eyes;

        [TestInitialize]
        public void init()
        {
            driver = new FirefoxDriver();

            // This is your api key, make sure you use it in all your tests.
            eyes = new Eyes();
            eyes.ApiKey = APPLITOOLS_APIKEY;
        }

        [TestMethod]
        public void Test()
        {
            driver.Navigate().GoToUrl("http://www.applitools.com");

            // Start visual testing with browser viewport set to 1024x768.
            // Make sure to use the returned driver from this point on.
            driver = eyes.Open(driver, "Applitools", "Test Web Page", new Size(1024, 768));

            // Visual validation point #1
            eyes.CheckWindow("Main Page");

            driver.FindElement(By.CssSelector(".features>a")).Click();

            // Visual validation point #2
            eyes.CheckWindow("Features Page");

            // End visual testing. Validate visual correctness.
            eyes.Close();
        }

        [TestCleanup]
        public void finalize()
        {
            eyes.AbortIfNotClosed();
            driver.Quit();
        }
    }
}
