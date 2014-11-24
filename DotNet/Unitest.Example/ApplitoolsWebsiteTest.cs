using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Applitools;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Drawing;

namespace Examples
{
    [TestClass]
    public class ApplitoolsWebsiteTest
    {
        private IWebDriver driver;
        private Eyes eyes;

        [TestInitialize]
        public void Init()
        {
            eyes = new Eyes();
            eyes.ApiKey = APPLITOOLS_APIKEY;
            driver = new ChromeDriver();
        }

        [TestMethod]
        public void TestApplitoolsWebsite()
        {
            driver.Navigate().GoToUrl("http://www.applitools.com");

            driver = eyes.Open(driver, "Applitools website", "Example test", new Size(900, 600));
            
            // Visual validation point #1
            eyes.CheckWindow("Main Page");
            
            driver.FindElement(By.ClassName("read_more")).Click();
            
            // Visual validation point #2
            eyes.CheckWindow("Features Page");
            
            eyes.Close();
        }

        [TestCleanup]
        public void TearDown()
        {
            eyes.AbortIfNotClosed();
            driver.Quit();
        }

    }
}
