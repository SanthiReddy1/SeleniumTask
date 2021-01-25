using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTask.PageLocators
{
    public class LoginPageLocators
    {
        public static By SignIn = By.XPath("//div[contains(@class,'myAccountTab')]");
        public static By LoginLink = By.XPath("//a[text()='login']");
        public static By LoginEmail = By.Name("username");
        public static By Continue = By.Id("checkUser");
        public static By LoginPassword = By.Id("j_password_login_uc");
        public static By Login = By.Id("submitLoginUC");
        public static By Frame = By.XPath("//iframe[@name='iframeLogin']");
    }
}
