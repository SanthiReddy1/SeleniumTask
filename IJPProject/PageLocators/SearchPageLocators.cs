using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTask.PageLocators
{
    public class SearchPageLocators
    {
        public static By Search = By.Id("inputValEnter");
        public static By Sort = By.XPath("//div[@class='sort-drop clearfix']");
    }
}
