using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTask.PageLocators
{
    public class ProductsPageLocators
    {
        public static By AddtoCart = By.XPath("//span[text()='add to cart']");
        public static By Cart = By.XPath("//div[contains(@class,'cartContainer ')]");
        public static By Container = By.ClassName("containerBreadcrumb");
        public static By Name = By.XPath("//h1[@itemprop='name']");
        public static By Price = By.XPath("//span[@itemprop='price']");
        public static By ProductsGrid = By.XPath("//div[@id='products']/section[@data-dpwlbl='Product Grid']/div[1]");
        public static By Item_Name = By.XPath("//a[@class='item-name']");
        public static By Item_Price = By.XPath("//span[@class='item-price']");
    }
}
