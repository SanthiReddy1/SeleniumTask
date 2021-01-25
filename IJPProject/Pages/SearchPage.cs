using OpenQA.Selenium;
using SeleniumTask.PageLocators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumTask.Pages
{
    public class SearchPage : SearchPageLocators
    {
        public IWebDriver _driver;        
        Synchronization sync;
        public SearchPage(IWebDriver driver)
        {
            _driver = driver;
            sync = new Synchronization(_driver);
        }

        public void SearchForAProduct(string product)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(5);
            sync.WaitUntilClickable(Search, 10);
            _driver.FindElement(Search).SendKeys(product);
            _driver.FindElement(Search).SendKeys(Keys.Enter);
        }

        public void ApplyFilter(string Filter)
        {
            sync.WaitUntilVisible(Sort, 10);
            _driver.FindElement(Sort).Click();
            _driver.FindElement(By.XPath("//li[contains(.,'" + Filter + "')]")).Click();
        }
    }
}
