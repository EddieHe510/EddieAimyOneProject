using AimyOneLoginTest.Drivers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AimyOneLoginTest.Components.LoginPageComponent
{
    public class Login: Hook
    {
        private IWebElement loginUsername => driver.FindElement(By.Id("Username"));
        private IWebElement loginPassword => driver.FindElement(By.Id("Password"));
        private IWebElement rememberMeCheckBox => driver.FindElement(By.Id("RememberLogin"));
        private IWebElement loginButton => driver.FindElement(By.XPath("/html/body/div/div/form/button[1]"));
        private IWebElement registerButton => driver.FindElement(By.XPath("/html/body/div/div/form/button[2]"));
        private IWebElement forgotPasswordButton => driver.FindElement(By.XPath("/html/body/div/div/form/div[1]/button"));

        private IWebElement actualUsername => driver.FindElement(By.XPath("/html/body/div/div/div/div/section/section/header/div/div/div[2]/div/span[1]"));
        private IWebElement errorMessage => driver.FindElement(By.XPath("/html/body/div/div/div/div/ul/li"));


        public void loginWithCredentails(string username, string password)
        {
            loginUsername.SendKeys(username);
            loginPassword.SendKeys(password);
            rememberMeCheckBox.Click();
            loginButton.Click();
        }

        public string assertUsername()
        {
            Wait.WaitToBeVisible("XPath", 20, "/html/body/div/div/div/div/section/section/header/div/div/div[2]/div/span[1]");
            return actualUsername.Text;
        }

        public string invalidCredentialsMessage()
        {
            Wait.WaitToBeVisible("XPath", 10, "/html/body/div/div/div/div/ul/li");
            return errorMessage.Text;
        }
    }
}
