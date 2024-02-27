using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AimyOneLoginTest.Drivers
{
    public class Wait: Hook
    {
        public static void WaitToBeClickable(string LocatorType, int seconds, string LocatorValue)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
            if (LocatorType == "XPath")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(LocatorValue)));
            }
            else if (LocatorType == "Id")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id(LocatorValue)));

            }
            else if (LocatorType == "CssSelector")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(LocatorValue)));

            }
            else if (LocatorType == "Name")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Name(LocatorValue)));

            }
        }
        public static void WaitToBeVisible(string LocatorType, int seconds, string LocatorValue)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));

            if (LocatorType == "XPath")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(LocatorValue)));
            }
            if (LocatorType == "Id")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(LocatorValue)));
            }
            if (LocatorType == "CssSelector")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(LocatorValue)));
            }
            else if (LocatorType == "Name")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Name(LocatorValue)));

            }
        }
    }
}
