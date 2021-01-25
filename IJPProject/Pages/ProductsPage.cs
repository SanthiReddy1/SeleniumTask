using NUnit.Framework;
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
    public class ProductsPage : ProductsPageLocators
    {
        public IWebDriver _driver;
        public Synchronization sync;
        IList<string> productNames = new List<string>();
        IList<string> ProductCosts = new List<string>();
        IList<string> Names = new List<string>();
        IList<string> Costs = new List<string>();
        
        public ProductsPage(IWebDriver driver)
        {
            _driver = driver;
            sync = new Synchronization(_driver);
        }
        public void AddProductsToCart(int count)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(5);
            string parentWindow = _driver.CurrentWindowHandle;
            sync.WaitUntilVisible(ProductsGrid, 100);
            IList<IWebElement> products = _driver.FindElements(ProductsGrid);

            for (int i = 0; i < count; i++) //get product names and costs
            {
                IList<string> window = null;      
                products[i].Click();
                window = _driver.WindowHandles;
                _driver.SwitchTo().Window(window[i+1]);
                sync.WaitUntilVisible(Container,5);
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView();", _driver.FindElement(Container));
                IWebElement name = _driver.FindElement(Name);
                IWebElement cost = _driver.FindElement(Price);
                productNames.Add(name.Text.Trim());
                ProductCosts.Add(cost.Text.Trim());
                _driver.FindElement(AddtoCart).Click();
                _driver.SwitchTo().Window(parentWindow);
            }
        }

        public void VerifyProductsIntheCart()
        {
            char[] charsToTrim = { 'R', 's', '.', '4' };
            _driver.Navigate().Refresh();
            sync.WaitUntilClickable(Cart,5);
            _driver.FindElement(Cart).Click();
            Thread.Sleep(2000);
            IList<IWebElement> PNames = _driver.FindElements(Item_Name);
            IList<IWebElement> Pcosts = _driver.FindElements(Item_Price);
            int ProductsCount = PNames.Count;

            for (int i = ProductsCount; i >0; i--) //Get name and cost of products in cart
            {
                Names.Add(PNames[i - 1].Text.Trim());
                Costs.Add(Pcosts[i - 1].Text.TrimStart(charsToTrim).Trim());
            }
            Assert.AreEqual(productNames, Names, "Both names of the product are not equal");
            Assert.AreEqual(ProductCosts, Costs, "Costs of the product are not equal");
        }
    }
}
