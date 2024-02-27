using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace AimyOneLoginTest.Drivers
{
    [TestFixture]
    public class Hook
    {
        public static IWebDriver driver;
        protected Browser browser;

        [BeforeScenario]
        public void StartWebsite()
        {
            Reporter.ReportingCreateTest(TestContext.CurrentContext.Test.MethodName);
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://uat-app.aimyone.com");
            
            browser = new Browser(driver);
        }



        [AfterScenario]
        public void CloseBrowser()
        {
            DriverEndTest();
            Reporter.ReportingEndRepoting();
            driver.Quit();
        }


        private void DriverEndTest()
        {
            var testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            var message = TestContext.CurrentContext.Result.Message;

            switch (testStatus)
            {
                case TestStatus.Failed:
                    Reporter.ReportingLogFail($"Test has failed {message}");
                    break;

                case TestStatus.Skipped:
                    Reporter.ReportingLogInfo($"Test skipped {message}");
                    break;

                default:
                    break;
            }

            Reporter.ReportingLogScreenShot("Ending test", browser.BroswerGetScreenShot());
        }
    }
}
