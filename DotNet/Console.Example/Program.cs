using System;
using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Applitools;

namespace MyTests
{
    public class TestApplitoolsWebsite
    {
        public static void Main(string[] args)
        {
            IWebDriver driver = new FirefoxDriver();

            // This is your api key, make sure you use it in all your tests.
            var eyes = new Eyes();
            eyes.ApiKey = APPLITOOLS_APIKEY;

            try
            {
                driver.Navigate().GoToUrl("http://www.applitools.com");

                // Start visual testing with browser viewport set to 1024x768.
                // Make sure to use the returned driver from this point on.
                driver = eyes.Open(driver, "Applitools website", "Example test", new Size(900, 600));

                // Visual validation point #1
                eyes.CheckWindow("Main Page");

                driver.FindElement(By.ClassName("read_more")).Click();

                // Visual validation point #2
                eyes.CheckWindow("Features Page");

                // End visual testing. Validate visual correctness.
                eyes.Close();
            }
            finally
            {
                eyes.AbortIfNotClosed();
                driver.Quit();
            }
        }
    }
}