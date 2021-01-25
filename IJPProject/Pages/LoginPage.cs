using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTask.PageLocators;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumTask.Pages
{
    public class LoginPage : LoginPageLocators
    {
        public IWebDriver _driver;       
        Synchronization sync;   
        public string username = ConfigurationManager.AppSettings["Username"];
        public string password = ConfigurationManager.AppSettings["Password"];

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            sync = new Synchronization(_driver);
        }
        public void LoginToTheApplication(string uname, string pwd)
        {
            sync.WaitUntilVisible(SignIn, 20);
            _driver.FindElement(SignIn).Click();
            _driver.FindElement(LoginLink).Click();
            sync.WaitUntilClickable(Frame, 5);
            _driver.SwitchTo().Frame(_driver.FindElement(Frame));//Login Frame
            sync.WaitUntilVisible(LoginEmail, 10);
            _driver.FindElement(LoginEmail).SendKeys(username);
            _driver.FindElement(Continue).Click();
            Thread.Sleep(500);
            _driver.FindElement(LoginPassword).SendKeys(password);
            _driver.FindElement(Login).Click();
            _driver.SwitchTo().DefaultContent();
        }  
    }
}
